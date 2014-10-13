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
}