using System;

namespace CommandLineLib
{
   public class SwitchArgument : BaseArgument
   {
      public SwitchArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label )
         : base( property, ordinal, optional, groups, description )
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

      public override string Description
      {
         get { return this.Prefix + this.Label; }
      }

      protected override object FromString( string value )
      {
         return ( 0 == String.Compare( value, this.Description, !this.CaseSensitive ) );
      }
   }
}
