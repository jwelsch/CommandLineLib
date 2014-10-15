using System;

namespace CommandLineLib
{
   public class CompoundValueArgument<T> : ValueArgument<T>
   {
      private SwitchArgument @switch;

      public CompoundValueArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, T[] acceptableValues )
         : base( property, attributeData, acceptableValues )
      {
         this.IsCompound = true;
         this.@switch = new SwitchArgument( property, attributeData, caseSensitive, prefix, label );
      }

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
      }

      public string Prefix
      {
         get { return this.@switch.Prefix; }
      }

      public string Label
      {
         get { return this.@switch.Label; }
      }

      protected override object FromString( string value )
      {
         return value;
      }

      public override bool MatchCommandLineArgument( string value )
      {
         return this.@switch.MatchCommandLineArgument( value );
      }
   }
}
