using System;

namespace CommandLineLib
{
   public class CompoundRangeValueArgument<T> : RangeValueArgument<T>
   {
      private SwitchArgument @switch;

      public CompoundRangeValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, T[] acceptableValues, T rangeMin, T rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
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

      public override bool MatchCommandLineArgument( string value )
      {
         return this.@switch.MatchCommandLineArgument( value );
      }
   }
}
