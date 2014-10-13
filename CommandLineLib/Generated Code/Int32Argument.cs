using System;

namespace CommandLineLib
{
   public class Int32ValueArgument : ValueArgument<Int32>
   {
      public Int32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int32[] acceptableValues, Int32 rangeMin, Int32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

