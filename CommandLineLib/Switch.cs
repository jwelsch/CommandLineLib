using System;
using System.Collections.Generic;
using System.Reflection;

namespace CommandLineLib
{
   public class Switch : BaseAttribute, ISwitchAttribute
   {
      public Switch( string identifier )
      {
         this.Identifier = identifier;
         this.ShortName = this.Identifier;
         this.Aliases = new string[0];
      }

      public bool CaseSensitive
      {
         get;
         set;
      }

      public string Identifier
      {
         get;
         private set;
      }

      public string[] Aliases
      {
         get;
         set;
      }

      public bool Reverse
      {
         get;
         set;
      }

      public string[] AllIdentifiers()
      {
         var identifiers = new List<string>();
         identifiers.Add( this.Identifier );
         identifiers.AddRange( this.Aliases );

         return identifiers.ToArray();
      }

      public override bool MatchArgument( string argument )
      {
         if ( 0 == String.Compare( this.Identifier, argument, !this.CaseSensitive ) )
         {
            return true;
         }

         if ( this.Aliases != null )
         {
            foreach ( var alias in this.Aliases )
            {
               if ( 0 == String.Compare( alias, argument, !this.CaseSensitive ) )
               {
                  return true;
               }
            }
         }

         return false;
      }

      public override void SetProperty( PropertyInfo property )
      {
         if ( property.PropertyType != typeof( bool ) )
         {
            throw new ArgumentTypeMismatchException( String.Format( "The switch argument \"{0}\" must be declared as a Boolean type.", this.ShortName ) );
         }

         base.SetProperty( property );
      }

      public override bool SetArgument( object instance, string argument )
      {
         this.Property.SetValue( instance, this.Reverse ? false : true );

         return true;
      }
   }
}
