using System;
using System.Reflection;

namespace CommandLineLib
{
   public class CompoundManager
   {
      private Switch @switch;
      private ValueBaseAttribute attribute;
      private string valueName;
      private string usageText;

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

      public string[] AllIdentifiers()
      {
         return this.@switch.AllIdentifiers();
      }

      public bool MatchArgument( string argument )
      {
         return this.@switch.MatchArgument( argument );
      }

      public string ShortName
      {
         get { return this.@switch.ShortName; }
         set { this.@switch.ShortName = value; }
      }

      public void SetValueName( string name )
      {
         this.valueName = name;
      }

      public string UsageText()
      {
         if ( String.IsNullOrEmpty( this.usageText ) )
         {
            var valueText = CommandLineUsage.GenerateUsageText( this.valueName, false, true );
            this.usageText = CommandLineUsage.GenerateUsageText( this.Identifier + " " + valueText, this.attribute.Optional, false );
         }

         return this.usageText;
      }
   }
}
