using System;

namespace CommandLineLib
{
   public class StringCompoundArgument : CompoundValueArgument<string>
   {
      public StringCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, string[] acceptableValues )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues )
      {
      }

      protected override object FromString( string value )
      {
         return value;
      }
   }
}
