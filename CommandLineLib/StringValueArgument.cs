using System;

namespace CommandLineLib
{
   public class StringValueArgument : ValueArgument<String>
   {
      public StringValueArgument( PropertyAccessor property, IAttributeData attributeData, String[] acceptableValues )
         : base( property, attributeData, acceptableValues )
      {
      }

      protected override object FromString( string value )
      {
         return value;
      }
   }
}