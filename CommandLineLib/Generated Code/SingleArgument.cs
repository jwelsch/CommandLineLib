using System;

namespace CommandLineLib
{
   public class SingleValueArgument : ValueArgument<Single>
   {
      public SingleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Single[] acceptableValues, Single rangeMin, Single rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

