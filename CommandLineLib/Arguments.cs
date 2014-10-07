using System;

namespace CommandLineLib
{
   public class StringValueArgument : ValueArgument<String>
   {
      public StringValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, String[] acceptableValues )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }

      protected override object FromString( string value )
      {
         return value;
      }
   }

   public class Int32ValueArgument : RangeValueArgument<Int32>
   {
      public Int32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int32[] acceptableValues, Int32 rangeMin, Int32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}