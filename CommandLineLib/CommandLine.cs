using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

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

   /***************************************************************************
    * TODO:
    * - Add more exceptions for different errors
    * - Add compound argument that can accept multiple values
    * 
    **************************************************************************/

   public class CommandLine<T>
   {
      private List<IBaseAttribute> attributes = new List<IBaseAttribute>();
      private string helpText;

      public CommandLine()
      {
         this.FindParameters();
         this.OrdinalCheck();
         this.SwitchCheck();
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

               attribute.SetProperty( propertyInfo );
               this.attributes.Add( attribute );
            }
         }

         if ( this.attributes.Count == 0 )
         {
            throw new CommandLineDeclarationException( String.Format( "No command line attributes found on class \"{0}\".", typeof( T ).Name ) );
         }

         this.attributes.Sort( ( arg1, arg2 ) =>
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
      }

      private void OrdinalCheck()
      {
         IBaseAttribute previousAttribute = null;
         var foundOptionalValue = false;

         foreach ( var attribute in this.attributes )
         {
            if ( attribute.Ordinal > 0 )
            {
               if ( previousAttribute != null )
               {
                  if ( ( previousAttribute.Ordinal == attribute.Ordinal )
                     && ( ( attribute as IValueAttribute != null )
                     || ( previousAttribute as IValueAttribute != null ) ) )
                  {
                     {
                        throw new CommandLineDeclarationException( String.Format( "A value argument was found with the same ordinal ({0}) as another argument.", attribute.Ordinal ) );
                     }
                  }
               }

               previousAttribute = attribute;
            }

            if ( ( attribute as IValueAttribute != null )
               && ( attribute as ICompoundAttribute == null ) )
            {
               if ( attribute.Optional )
               {
                  foundOptionalValue = true;
               }
               else if ( foundOptionalValue )
               {
                  throw new CommandLineDeclarationException( String.Format( "The required value argument, \"{0}\", cannot follow an optional value argument unless they are separated by a switch or compound argument.", attribute.ShortName ) );
               }
            }
            else if ( attribute as ISwitchAttribute != null )
            {
               foundOptionalValue = false;
            }
            else
            {
               throw new CommandLineDeclarationException( String.Format( "Unknown argument type \"{0}\".", attribute.GetType().Name ) );
            }
         }
      }

      private void SwitchCheck()
      {
         for ( var i = 0; i < this.attributes.Count; i++ )
         {
            var switchAttribute = this.attributes[i] as ISwitchAttribute;
            if ( switchAttribute != null )
            {
               var switchAttributeIdentifiers = switchAttribute.AllIdentifiers();

               if ( switchAttributeIdentifiers.ContainsDuplicate<string>() )
               {
                  throw new CommandLineDeclarationException( String.Format( "The argument \"{0}\" contains a duplicate alias or identifier.", switchAttribute.ShortName ) );
               }

               for ( var j = 0; j < switchAttributeIdentifiers.Length; j++ )
               {
                  foreach ( var c in switchAttributeIdentifiers[j] )
                  {
                     if ( Char.IsWhiteSpace( c ) )
                     {
                        throw new CommandLineDeclarationException( String.Format( "The identifier or alias for the switch or compound argument, \"{0}\", cannot contain whitespace characters.", switchAttribute.Identifier ) );
                     }
                  }

                  for ( var k = i + 1; k < this.attributes.Count; k++ )
                  {
                     var otherSwitch = this.attributes[k] as ISwitchAttribute;
                     if ( otherSwitch != null )
                     {
                        if ( otherSwitch.MatchArgument( switchAttributeIdentifiers[j] ) )
                        {
                           throw new CommandLineDeclarationException( String.Format( "More than one switch or compound argument has the same identifier or alias \"{0}\".", switchAttribute.ToString() ) );
                        }
                     }
                  }
               }
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
         var matchedAttributeList = new List<IBaseAttribute>();
         var unmatchedAttributeList = new List<IBaseAttribute>( this.attributes );

         for ( var i = 0; i < args.Length; i++ )
         {
            var matched = false;

            for ( var j = 0; j < unmatchedAttributeList.Count; j++ )
            {
               if ( unmatchedAttributeList[j].MatchArgument( args[i] ) )
               {
                  if ( !this.IsGroupAllowed( acceptedGroups, unmatchedAttributeList[j].Groups ) )
                  {
                     throw new GroupNotAllowedException( String.Format( "The argument \"{0}\" is not allowed because of its group.", unmatchedAttributeList[j].ShortName ) );
                  }

                  if ( ( unmatchedAttributeList[j].Ordinal != 0 )
                     && ( unmatchedAttributeList[j].Ordinal < currentOrdinal ) )
                  {
                     throw new ArgumentOutOfOrderException( String.Format( "The argument \"{0}\" is out of order.", unmatchedAttributeList[j].ShortName ) );
                  }

                  if ( unmatchedAttributeList[j].IsCompound )
                  {
                     if ( i + 1 >= args.Length )
                     {
                        throw new CompoundArgumentValueMissingException( String.Format( "Missing value for the compound argument \"{0}\".", unmatchedAttributeList[j].ShortName ) );
                     }

                     i++;
                  }

                  unmatchedAttributeList[j].SetArgument( outputObject, args[i] );

                  matched = true;

                  currentOrdinal = ( unmatchedAttributeList[j].Ordinal == 0 ? currentOrdinal : unmatchedAttributeList[j].Ordinal );

                  matchedAttributeList.Add( unmatchedAttributeList[j] );
                  unmatchedAttributeList.RemoveAt( j );

                  break;
               }
            }

            if ( !matched )
            {
               foreach ( var argument in matchedAttributeList )
               {
                  if ( argument.MatchArgument( args[i] ) )
                  {
                     throw new DuplicateArgumentException( String.Format( "Duplicate \"{0}\" argument found.", argument.ShortName ) );
                  }
               }
            }
         }

         foreach ( var argInfo in unmatchedAttributeList )
         {
            var common = argInfo.Groups.Common( acceptedGroups );
            var onlyBelongsToZero = argInfo.Groups.Contains( 0 ) && ( argInfo.Groups.Length == 1 );

            if ( !argInfo.Optional && ( onlyBelongsToZero ? true : common.Count > 0 ) )
            {
               throw new ArgumentNotFoundException( String.Format( "The mandatory argument \"{0}\" was not found.", argInfo.ShortName ) );
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

      public string Help()
      {
         return this.Help( AssemblyData.FileName );
      }

      public string Help( string assemblyFileName )
      {
         return this.Help( AssemblyData.FileName, AssemblyData.AssemblyVersion );
      }

      public string Help( string assemblyFileName, Version assemblyVersion )
      {
         if ( String.IsNullOrEmpty( this.helpText ) )
         {
            var commandLineUsage = new CommandLineUsage();
            this.helpText = commandLineUsage.Generate( this.attributes, assemblyFileName, assemblyVersion );
         }

         return this.helpText;
      }
   }
}