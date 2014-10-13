using System;

namespace CommandLineLib
{
   public class UInt64ValueArgument : ValueArgument<UInt64>
   {
      public UInt64ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt64[] acceptableValues, UInt64 rangeMin, UInt64 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

