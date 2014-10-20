using System;
using System.Reflection;

namespace CommandLineLib
{
   public class CompoundManager
   {
      private Switch @switch;
      private ValueBaseAttribute attribute;

      public CompoundManager( ValueBaseAttribute attribute, string identifier )
      {
         this.attribute = attribute;
         typeof( ValueBaseAttribute ).GetProperty( "IsCompound", typeof( bool ) ).SetValue( this.attribute, true );
         this.@switch = new Switch( identifier );
      }

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
         set { this.@switch.CaseSensitive = value; }
      }

      public string Identifier
      {
         get { return this.@switch.Identifier; }
      }

      public string[] Aliases
      {
         get { return this.@switch.Aliases; }
         set { this.@switch.Aliases = value; }
      }

      public bool MatchArgument( string argument )
      {
         return this.@switch.MatchArgument( argument );
      }

      public string ShortName
      {
         get { return this.@switch.ShortName; }
      }

      public string UsageText( string valueUsageText )
      {
         return String.Format( "{0} {1}", this.@switch.Identifier, valueUsageText );
      }
   }
}
