using System;

namespace CommandLineLib
{
   public class CompoundRangeValueArgument<T> : RangeValueArgument<T>
   {
      private SwitchArgument @switch;

      public CompoundRangeValueArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, T[] acceptableValues, T rangeMin, T rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
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

      public override bool MatchCommandLineArgument( string value )
      {
         return this.@switch.MatchCommandLineArgument( value );
      }
   }
}
