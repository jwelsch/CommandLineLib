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
         var unresolvedArgumentList = this.FindParameters( argumentObject );
         var resolvedArgumentList = new List<IBaseArgument>();

         if ( unresolvedArgumentList.Count == 0 )
         {
            throw new CommandLineException( String.Format( "No command line attributes found on class \"{0}\".", typeof( T ).Name ) );
         }

         var state = unresolvedArgumentList[0] as SwitchArgument == null ? State.Value : State.Switch;
         var acceptedGroups = new List<int>();
         var currentOrdinal = 1;

         foreach ( var arg in args )
         {
            for ( var i = 0; i < unresolvedArgumentList.Count; i++ )
            {
               if ( !this.IsGroupAllowed( acceptedGroups, unresolvedArgumentList[i].Groups ) )
               {
                  throw new CommandLineException( String.Format( "The argument \"{0}\" is not allowed because of its group.", unresolvedArgumentList[i].Description ) );
               }

               if ( unresolvedArgumentList[i].WasSet )
               {
                  throw new CommandLineException( String.Format( "Duplicate \"{0}\" argument found.", unresolvedArgumentList[i].Description ) );
               }

               if ( unresolvedArgumentList[i].SetFromCommandLineArgument( arg ) )
               {
                  if ( ( unresolvedArgumentList[i].Ordinal != 0 )
                     && ( unresolvedArgumentList[i].Ordinal < currentOrdinal ) )
                  {
                     throw new CommandLineException( String.Format( "The argument \"{0}\" is out of order.", unresolvedArgumentList[i].Description ) );
                  }

                  currentOrdinal = ( unresolvedArgumentList[i].Ordinal == 0 ? currentOrdinal : unresolvedArgumentList[i].Ordinal );
                  resolvedArgumentList.Add( unresolvedArgumentList[i] );
                  unresolvedArgumentList.RemoveAt( i );
                  break;
               }
            }
         }

         foreach ( var argInfo in unresolvedArgumentList )
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

         var current = 0;
         IBaseArgument previous = null;

         foreach ( var argument in arguments )
         {
            if ( argument.Ordinal > 0 )
            {
               if ( argument.Ordinal != current )
               {
                  if ( previous != null )
                  {
                     if ( ( previous as ValueArgument<T> == null ) )
                     {
                        throw new CommandLineException( String.Format( "More than one value argument was assigned to ordinal \"{0}\".", argument.Ordinal ) );
                     }
                  }

                  current = argument.Ordinal;
                  previous = argument;
               }
            }
         }

         return arguments;
      }
   }
}