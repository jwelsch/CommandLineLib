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

      private AttibutePropertyBinder unboundAttributes = new AttibutePropertyBinder();

      public CommandLine()
      {
         this.FindParameters();
         this.OrdinalCheck();
      }

      private void FindParameters()
      {
         var type = typeof( T );

         foreach ( var memberInfo in type.GetMembers() )
         {
            foreach ( var attribute in memberInfo.GetCustomAttributes<BaseAttribute>() )
            {
               var propertyInfo = memberInfo as PropertyInfo;

               if ( propertyInfo == null )
               {
                  throw new CommandLineDeclarationException( String.Format( "\"{0}\" is not a property and cannot have a command line attribute.", memberInfo.Name ) );
               }

               this.unboundAttributes.Add( attribute, propertyInfo );
            }
         }

         if ( this.unboundAttributes.Pairs.Count == 0 )
         {
            throw new CommandLineDeclarationException( String.Format( "No command line attributes found on class \"{0}\".", typeof( T ).Name ) );
         }

         this.unboundAttributes.Pairs.Sort( ( arg1, arg2 ) =>
         {
            if ( ( arg1.Attribute.Ordinal < 0 ) && ( arg2.Attribute.Ordinal < 0 ) )
            {
               return 0;
            }
            else if ( arg1.Attribute.Ordinal < 0 )
            {
               return 1;
            }
            else if ( arg2.Attribute.Ordinal < 0 )
            {
               return -1;
            }
            else if ( arg1.Attribute.Ordinal < arg2.Attribute.Ordinal )
            {
               return -1;
            }
            else if ( arg1.Attribute.Ordinal > arg2.Attribute.Ordinal )
            {
               return 1;
            }

            return 0;
         } );
      }

      private void OrdinalCheck()
      {
         IBaseAttribute previousAttribute = null;
         var foundOptionalValue = false;

         foreach ( var pair in this.unboundAttributes.Pairs )
         {
            if ( pair.Attribute.Ordinal > 0 )
            {
               if ( previousAttribute != null )
               {
                  if ( ( previousAttribute.Ordinal == pair.Attribute.Ordinal )
                     && ( ( pair.Attribute as IValueAttribute != null )
                     || ( previousAttribute as IValueAttribute != null ) ) )
                  {
                     {
                        throw new CommandLineDeclarationException( String.Format( "A value argument was found with the same ordinal ({0}) as another argument.", pair.Attribute.Ordinal ) );
                     }
                  }
               }

               previousAttribute = pair.Attribute;
            }

            if ( pair.Attribute as IValueAttribute != null )
            {
               if ( pair.Attribute.Optional )
               {
                  foundOptionalValue = true;
               }
               else if ( foundOptionalValue )
               {
                  throw new CommandLineDeclarationException( String.Format( "The required value argument, \"{0}\", cannot follow an optional value argument unless they are separated by a switch argument.", pair.Attribute.Description ) );
               }
            }
            else if ( pair.Attribute as ISwitchAttribute != null )
            {
               foundOptionalValue = false;
            }
            else
            {
               throw new CommandLineDeclarationException( String.Format( "Unknown argument type \"{0}\".", pair.Attribute.GetType().Name ) );
            }

            if ( !pair.Attribute.CheckPropertyType( pair.Property ) )
            {
               throw new CommandLineDeclarationException( String.Format( "The property \"{0}\" has the wrong type for the command line attribute that it is decorated with.", pair.Property.Name ) );
            }
         }
      }

      public T Parse( string arg )
      {
         return this.Parse( new string[] { arg } );
      }

      public T Parse( string[] args )
      {
         var acceptedGroups = new List<int>();
         var currentOrdinal = 1;
         var outputObject = (T) Activator.CreateInstance( typeof( T ) );
         var unmatchedArgumentList = this.unboundAttributes.Bind( outputObject );
         var matchedArgumentList = new List<IBaseArgument>();

         foreach ( var arg in args )
         {
            var matched = false;

            for ( var i = 0; i < unmatchedArgumentList.Count; i++ )
            {
               if ( unmatchedArgumentList[i].MatchCommandLineArgument( arg ) )
               {
                  if ( unmatchedArgumentList[i].WasSet )
                  {
                     throw new CommandLineException( String.Format( "Duplicate \"{0}\" argument found.", unmatchedArgumentList[i].Description ) );
                  }

                  if ( !this.IsGroupAllowed( acceptedGroups, unmatchedArgumentList[i].Groups ) )
                  {
                     throw new CommandLineException( String.Format( "The argument \"{0}\" is not allowed because of its group.", unmatchedArgumentList[i].Description ) );
                  }

                  if ( ( unmatchedArgumentList[i].Ordinal != 0 )
                     && ( unmatchedArgumentList[i].Ordinal < currentOrdinal ) )
                  {
                     throw new CommandLineException( String.Format( "The argument \"{0}\" is out of order.", unmatchedArgumentList[i].Description ) );
                  }

                  unmatchedArgumentList[i].SetFromCommandLineArgument( arg );
                  matched = true;

                  currentOrdinal = ( unmatchedArgumentList[i].Ordinal == 0 ? currentOrdinal : unmatchedArgumentList[i].Ordinal );

                  matchedArgumentList.Add( unmatchedArgumentList[i] );
                  unmatchedArgumentList.RemoveAt( i );

                  break;
               }
            }

            if ( !matched )
            {
               foreach ( var argument in matchedArgumentList )
               {
                  if ( argument.MatchCommandLineArgument( arg ) )
                  {
                     throw new CommandLineException( String.Format( "Duplicate \"{0}\" argument found.", argument.Description ) );
                  }
               }
            }
         }

         foreach ( var argInfo in unmatchedArgumentList )
         {
            if ( !argInfo.Optional && !argInfo.WasSet )
            {
               throw new CommandLineException( String.Format( "The mandatory argument \"{0}\" was not found.", argInfo.Description ) );
            }
         }

         return outputObject;
      }

      private bool IsGroupAllowed( List<int> acceptedGroups, int[] argumentGroups )
      {
         var result = false;

         if ( ( argumentGroups.Length == 1 ) && ( argumentGroups[0] == 0 ) )
         {
            result = true;
         }
         else
         {
            var argumentGroupsNoZero = argumentGroups.Remove( 0 );

            if ( acceptedGroups.Count == 0 )
            {
               acceptedGroups.AddRange( argumentGroupsNoZero );
               result = true;
            }
            else
            {
               var common = acceptedGroups.Common<int>( argumentGroupsNoZero );

               result = common.Count > 0;

               if ( result )
               {
                  acceptedGroups.Clear();
                  acceptedGroups.AddRange( common );
               }
            }
         }

         return result;
      }
   }
}