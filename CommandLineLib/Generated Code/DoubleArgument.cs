using System;

namespace CommandLineLib
{
   public class DoubleValueArgument : ValueArgument<Double>
   {
      public DoubleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

