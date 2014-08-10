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

         argumentInfo.Sort( ( arg1, arg2 ) =>
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

         var state = argumentInfo[0].Argument as Value != null ? State.Value : State.Switch;
         var nextOrdinal = argumentInfo[0].Argument.Ordinal;

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

                  if ( String.Compare( @switch, arg, switchArgument.CaseSensitive ) == 0 )
                  {
                     if ( argumentInfo[i].Property.WasSet )
                     {
                        throw new CommandLineException( String.Format( "Duplicate \"{0}\" switch found.", @switch ) );
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
               throw new CommandLineException( String.Format( "The mandatory argument \"{0}\" was not found.", argInfo.Argument. ) );
            }
         }

         return commandLineArguments;
      }

      private List<ArgumentInfo> FindParameters( T commandLineArguments )
      {
         var arguments = new List<ArgumentInfo>();
         var properties = typeof( T ).GetProperties( BindingFlags.Instance | BindingFlags.Public );

         foreach ( var property in properties )
         {
            var allAttributes = property.GetCustomAttributes( typeof( IBaseArgument ), false );

            foreach ( var allAttribute in allAttributes )
            {
               if ( allAttribute as IBaseArgument != null )
               {
                  var attribute = (IBaseArgument) allAttribute;
                  arguments.Add( new ArgumentInfo( attribute, new ArgumentPropertyBinding( commandLineArguments, property ) ) );
                  break;
               }
            }
         }

         return arguments;
      }
   }
}