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

      public T Parse( string arg )
      {
         return this.Parse( new string[] { arg } );
      }

      public T Parse( string[] args )
      {
         var argumentObject = (T) Activator.CreateInstance( typeof( T ) );
         var argumentList = this.FindParameters( argumentObject );

         if ( argumentList.Count == 0 )
         {
            throw new CommandLineException( String.Format( "No command line attributes found on class \"{0}\".", typeof( T ).Name ) );
         }

         var state = argumentList[0] as SwitchArgument == null ? State.Value : State.Switch;
         var currentOrdinal = 0;
         var acceptedGroups = new List<int>();

         foreach ( var arg in args )
         {
            for ( var i = 0; i < argumentList.Count; i++ )
            {
               if ( state == State.Value )
               {
                  try
                  {
                     argumentList[i].SetFromCommandLineArgument( arg );
                  }
                  catch ( UnacceptableArgumentException )
                  {
                     throw new CommandLineException( String.Format( "Unacceptable value \"{0}\" for argument \"{1}\"", arg, argumentList[i].Description ) );
                  }
                  catch ( ArgumentOutOfRangeException )
                  {
                     throw new CommandLineException( String.Format( "Value \"{0}\" is out of range for argument \"{1}\"", arg, argumentList[i].Description ) );
                  }
               }
               else if ( state == State.Switch )
               {
                  var switchArgument = (SwitchArgument) argumentList[i];
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

                     if ( argumentList[i].WasSet )
                     {
                        throw new CommandLineException( String.Format( "Duplicate \"{0}\" switch found.", switchArgument.Description ) );
                     }

                     if ( ( switchArgument.Ordinal > 0 )
                        && ( switchArgument.Ordinal > currentOrdinal ) )
                     {
                        currentOrdinal = switchArgument.Ordinal;
                     }

                     argumentList[i].SetFromCommandLineArgument( arg );

                     break;
                  }
               }
            }
         }

         foreach ( var argInfo in argumentList )
         {
            if ( !argInfo.Optional && !argInfo.WasSet )
            {
               throw new CommandLineException( String.Format( "The mandatory argument \"{0}\" was not found.", argInfo.Description ) );
            }
         }

         return argumentObject;
      }

      private bool IsGroupAllowed( List<int> acceptedGroups, int[] argumentGroups )
      {
         var result = false;

         if ( acceptedGroups.Count == 0 )
         {
            acceptedGroups.AddRange( argumentGroups );
            result = true;
         }
         else
         {
            var common = acceptedGroups.Common<int>( argumentGroups );

            result = common.Count > 0;

            if ( result )
            {
               acceptedGroups.Clear();
               acceptedGroups.AddRange( common );
            }
         }

         return result;
      }

      private List<IBaseArgument> FindParameters( T argumentObject )
      {
         var arguments = new List<IBaseArgument>();
         var properties = typeof( T ).GetProperties( BindingFlags.Instance | BindingFlags.Public );

         foreach ( var property in properties )
         {
            var allAttributes = property.GetCustomAttributes( typeof( IBaseAttribute ), false );

            if ( allAttributes.Length > 0 )
            {
               var attribute = (IBaseAttribute) allAttributes[0];
               var argument = attribute.CreateArgument( argumentObject, property );
               arguments.Add( argument );
            }
         }

         arguments.Sort( ( arg1, arg2 ) =>
         {
            if ( ( arg1.Ordinal < 0 ) && ( arg2.Ordinal < 0 ) )
            {
               return 0;
            }
            else if ( arg1.Ordinal < 0 )
            {
               return 1;
            }
            else if ( arg2.Ordinal < 0 )
            {
               return -1;
            }
            else if ( arg1.Ordinal < arg2.Ordinal )
            {
               return -1;
            }
            else if ( arg1.Ordinal > arg2.Ordinal )
            {
               return 1;
            }

            return 0;
         } );

         return arguments;
      }
   }
}