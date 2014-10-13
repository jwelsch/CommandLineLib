using System;

namespace CommandLineLib
{
   public class Int16ValueArgument : ValueArgument<Int16>
   {
      public Int16ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int16[] acceptableValues, Int16 rangeMin, Int16 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

