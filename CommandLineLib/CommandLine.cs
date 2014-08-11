using System;
using System.Collections.Generic;
using System.Reflection;

namespace CommandLineLib
{
   /***************************************************************************
    * Command Line Argument Types
    * 
    * - Switch argument: The presence of the switch acts as a boolean value.
    * - Value argument: Simply a value on the command line.
    * - Compound argument: Consists of a switch followed by a value, separated
    *                      by a space.
    * 
    * Other Considerations
    * 
    * - Case sensitivity
    * - Aliases
    * - Ordering
    * - Grouping/mutual exclusivity
    * - Optional
    * - Mandatory
    * - Acceptable values
    * 
    **************************************************************************/

   public class CommandLine<T>
   {
      private enum State
      {
         Unknown,
         Switch,
         Value
      }

      public T Parse( string[] args )
      {
         var commandLineArguments = (T) Activator.CreateInstance( typeof( T ) );
         var argumentInfo = this.FindParameters( commandLineArguments );

         if ( argumentInfo.Count == 0 )
         {
            throw new CommandLineException( String.Format( "No command line attributes found on class \"{0}\".", typeof( T ).Name ) );
         }

         var state = argumentInfo[0].Argument as Value != null ? State.Value : State.Switch;
         var currentOrdinal = 0;
         var acceptedGroups = new List<int>();

         foreach ( var arg in args )
         {
            for ( var i = 0; i < argumentInfo.Count; i++ )
            {
               if ( state == State.Value )
               {
               }
               else if ( state == State.Switch )
               {
                  var switchArgument = (ISwitchArgument) argumentInfo[i].Argument;
                  var @switch = switchArgument.Prefix + switchArgument.Label;

                  if ( String.Compare( @switch, arg, !switchArgument.CaseSensitive ) == 0 )
                  {
                     if ( ( switchArgument.Ordinal > 0 )
                        && ( switchArgument.Ordinal < currentOrdinal ) )
                     {
                        throw new CommandLineException( String.Format( "The switch \"{0}\" was specified out of order.", switchArgument.Description ) );
                     }

                     if ( !this.IsGroupAllowed( acceptedGroups, switchArgument.Groups ) )
                     {
                        throw new CommandLineException( String.Format( "An argument \"{0}\" is not allowed because of its group.", switchArgument.Description ) );
                     }

                     if ( argumentInfo[i].Property.WasSet )
                     {
                        throw new CommandLineException( String.Format( "Duplicate \"{0}\" switch found.", switchArgument.Description ) );
                     }

                     if ( ( switchArgument.Ordinal > 0 )
                        && ( switchArgument.Ordinal > currentOrdinal ) )
                     {
                        currentOrdinal = switchArgument.Ordinal;
                     }

                     argumentInfo[i].Property.Value = true;
                     break;
                  }
               }
            }
         }

         foreach ( var argInfo in argumentInfo )
         {
            if ( !argInfo.Argument.Optional && !argInfo.Property.WasSet )
            {
               throw new CommandLineException( String.Format( "The mandatory argument \"{0}\" was not found.", argInfo.Argument.Description ) );
            }
         }

         return commandLineArguments;
      }

      private bool IsGroupAllowed( List<int> acceptedGroups, int[] argumentGroups )
      {
         var result = false;

         if ( acceptedGroups.Count == 0 )
         {
            acceptedGroups.AddRange( argumentGroups );
            result = true;
         }
         else if ( acceptedGroups.Count > argumentGroups.Length )
         {
            for ( var i = acceptedGroups.Count; i >= 0; i-- )
            {
               if ( 0 < Array.IndexOf<int>( argumentGroups, acceptedGroups[i] ) )
               {
                  acceptedGroups.RemoveAt( i );
               }
               else
               {
                  result = true;
               }
            }
         }
         else
         {
            foreach ( var group in argumentGroups )
            {
               if ( acceptedGroups.Contains( group ) )
               {
                  result = true;
                  break;
               }
            }
         }

         return result;
      }

      private List<ArgumentInfo> FindParameters( T commandLineArguments )
      {
         var arguments = new List<ArgumentInfo>();
         var properties = typeof( T ).GetProperties( BindingFlags.Instance | BindingFlags.Public );

         foreach ( var property in properties )
         {
            var allAttributes = property.GetCustomAttributes( typeof( IBaseArgument ), false );

            if ( allAttributes.Length > 0 )
            {
               var attribute = (IBaseArgument) allAttributes[0];
               arguments.Add( new ArgumentInfo( attribute, new ArgumentPropertyBinding( commandLineArguments, property ) ) );
            }
         }

         arguments.Sort( ( arg1, arg2 ) =>
         {
            if ( ( arg1.Argument.Ordinal < 0 ) && ( arg2.Argument.Ordinal < 0 ) )
            {
               return 0;
            }
            else if ( arg1.Argument.Ordinal < 0 )
            {
               return 1;
            }
            else if ( arg2.Argument.Ordinal < 0 )
            {
               return -1;
            }
            else if ( arg1.Argument.Ordinal < arg2.Argument.Ordinal )
            {
               return -1;
            }
            else if ( arg1.Argument.Ordinal > arg2.Argument.Ordinal )
            {
               return 1;
            }

            return 0;
         } );

         return arguments;
      }
   }
}