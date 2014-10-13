using System;

namespace CommandLineLib
{
   public class UInt16ValueArgument : ValueArgument<UInt16>
   {
      public UInt16ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt16[] acceptableValues, UInt16 rangeMin, UInt16 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

