using System;

namespace CommandLineLib
{
   public class Int64ValueArgument : ValueArgument<Int64>
   {
      public Int64ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int64[] acceptableValues, Int64 rangeMin, Int64 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

