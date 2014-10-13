using System;

namespace CommandLineLib
{
   public class SByteValueArgument : ValueArgument<SByte>
   {
      public SByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, SByte[] acceptableValues, SByte rangeMin, SByte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

