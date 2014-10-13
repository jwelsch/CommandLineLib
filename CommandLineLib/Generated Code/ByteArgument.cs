using System;

namespace CommandLineLib
{
   public class ByteValueArgument : ValueArgument<Byte>
   {
      public ByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

