using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Switch : BaseAttribute, ISwitchAttribute
   {
      public Switch( string identifier )
      {
         this.Identifier = identifier;
         this.ShortName = this.Identifier;
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

      public override bool MatchArgument( string argument )
      {
         return ( 0 == String.Compare( this.Identifier, argument, !this.CaseSensitive ) );
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
         this.Property.SetValue( instance, true );

         return true;
      }
   }

}
