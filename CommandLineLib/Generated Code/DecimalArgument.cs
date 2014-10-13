using System;

namespace CommandLineLib
{
   public class DecimalValueArgument : ValueArgument<Decimal>
   {
      public DecimalValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Decimal[] acceptableValues, Decimal rangeMin, Decimal rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

