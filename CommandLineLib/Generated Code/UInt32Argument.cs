using System;

namespace CommandLineLib
{
   public class UInt32ValueArgument : ValueArgument<UInt32>
   {
      public UInt32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt32[] acceptableValues, UInt32 rangeMin, UInt32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

