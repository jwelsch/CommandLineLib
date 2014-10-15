using System;

namespace CommandLineLib
{
   public class SwitchArgument : BaseArgument
   {
      public SwitchArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label )
         : base( property, attributeData )
      {
         this.CaseSensitive = caseSensitive;
         this.Prefix = prefix;
         this.Label = label;
      }

      public bool CaseSensitive
      {
         get;
         private set;
      }

      public string Prefix
      {
         get;
         private set;
      }

      public string Label
      {
         get;
         private set;
      }

      public override bool MatchCommandLineArgument( string value )
      {
         return ( 0 == String.Compare( value, this.Prefix + this.Label, !this.CaseSensitive ) );
      }

      public override void SetFromCommandLineArgument( string value )
      {
         this.Property.SetValue( true );
      }
   }
}
