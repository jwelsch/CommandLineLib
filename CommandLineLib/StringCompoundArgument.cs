using System;

namespace CommandLineLib
{
   public class StringCompoundArgument : CompoundValueArgument<string>
   {
      public StringCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, string[] acceptableValues )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues )
      {
      }

      protected override object FromString( string value )
      {
         return value;
      }
   }
}
