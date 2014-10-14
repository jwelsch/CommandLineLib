using System;

namespace CommandLineLib
{
   public class CompoundValueArgument<T> : ValueArgument<T>
   {
      private SwitchArgument @switch;

      public CompoundValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, T[] acceptableValues )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
         this.IsCompound = true;
         this.@switch = new SwitchArgument( property, ordinal, optional, groups, description, caseSensitive, prefix, label );
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
