using System;

namespace CommandLineLib
{
   public class CompoundManager
   {
      private Switch @switch;

      public CompoundManager( BaseAttribute attribute, string prefix, string label )
      {
         ( typeof( BaseAttribute ) ).GetProperty( "IsCompound", typeof( bool ) ).SetValue( attribute, true );
         this.@switch = new Switch( prefix, label );
      }

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
         set { this.@switch.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.@switch.Prefix; }
      }

      public string Label
      {
         get { return this.@switch.Label; }
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
   }
}
