using System;
using CommandLineLib;

namespace CommandLineTest
{
   public class SingleSwitchArguments
   {
      [Switch( "-", "foo" )]
      public bool Foo
      {
         get;
         private set;
      }
   }

   public class DoubleSwitchArguments
   {
      [Switch( "-", "foo" )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( "-", "bar" )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class OptionalSwitchArguments
   {
      [Switch( "-", "foo", Optional = true )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( "-", "bar", Optional = true )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class CaseSensitiveSwitchArguments
   {
      [Switch( "-", "foo", CaseSensitive = true )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( "-", "bar", CaseSensitive = false )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class OrdinalSwitchArguments
   {
      [Switch( "-", "red", Ordinal = 1 )]
      public bool Red
      {
         get;
         private set;
      }

      [Switch( "-", "green", Ordinal = -1 )]
      public bool Green
      {
         get;
         private set;
      }

      [Switch( "-", "blue", Ordinal = 2 )]
      public bool Blue
      {
         get;
         private set;
      }

      [Switch( "-", "black", Ordinal = 1 )]
      public bool Black
      {
         get;
         private set;
      }
   }

   public class GroupSwitchArguments
   {
      [Switch( "-", "red", Groups = new int[] { 1, 2 } )]
      public bool Red
      {
         get;
         private set;
      }

      [Switch( "-", "green", Groups = new int[] { 2, 3 } )]
      public bool Green
      {
         get;
         private set;
      }

      [Switch( "-", "blue", Optional = true, Groups = new int[] { 3 } )]
      public bool Blue
      {
         get;
         private set;
      }
   }

   public class SimpleValueArgument
   {
      [Int32Value( 1 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class AcceptableValueArgument
   {
      [Int32Value( 1, AcceptableValues = new int[] { 1, 3, 5, 8 } )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class RangeValueArgument
   {
      [Int32Value( 1, RangeMax = 47, RangeMin = -3 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class InvalidRangeValueArgument
   {
      [Int32Value( 1, RangeMin = 47, RangeMax = -3 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class StringValueArgument
   {
      [StringValue( 1 )]
      public String StringValue
      {
         get;
         private set;
      }
   }

   public class AcceptableStringValueArgument
   {
      [StringValue( 1, AcceptableValues = new string[] { "foo", "bar" } )]
      public String StringValue
      {
         get;
         private set;
      }
   }

   public class MultipleValueArguments
   {
      [Int32Value( 6, RangeMin = 0, RangeMax = 10 )]
      public Int32 Int32Value4
      {
         get;
         private set;
      }

      [Int32Value( 5, RangeMax = 0 )]
      public Int32 Int32Value3
      {
         get;
         private set;
      }

      [Int32Value( 4, RangeMin = 0 )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }

      [Int32Value( 3, AcceptableValues = new int[] { -1, 0, 1 } )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }

      [StringValue( 1, AcceptableValues = new string[] { "foo", "bar" } )]
      public String StringValue1
      {
         get;
         private set;
      }

      [StringValue( 2 )]
      public String StringValue2
      {
         get;
         private set;
      }

      [Switch( "-", "a" )]
      public bool Switch1
      {
         get;
         private set;
      }
   }

   public class SameOrdinalValueArguments
   {
      [Int32Value( 1 )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }

      [Int32Value( 1 )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }
   }

   public class SameOrdinalValueSwitchArguments
   {
      [Switch( "-", "foo", Ordinal = 1 )]
      public Int32 Switch1
      {
         get;
         private set;
      }

      [Int32Value( 1 )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }
   }

   public class MultipleOrdinalValueSwitchArguments
   {
      [Switch( "-", "red", Optional = true, Ordinal = 2 )]
      public bool Switch1
      {
         get;
         private set;
      }

      [Switch( "-", "blue", Optional = true, Ordinal = 2 )]
      public bool Switch2
      {
         get;
         private set;
      }

      [Int32Value( 4, Optional = true )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }

      [StringValue( 3 )]
      public String StringValue1
      {
         get;
         private set;
      }

      [Int32Value( 1 )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }
   }

   public class IllegalOptionalValueArguments
   {
      [Int32Value( 1, Optional = true )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }

      [Int32Value( 2 )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }
   }

   public class LegalOptionalValueArguments
   {
      [Int32Value( 2, Optional = true )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }

      [Int32Value( 1 )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }

      [Int32Value( 3, Optional = true )]
      public Int32 Int32Value3
      {
         get;
         private set;
      }

      [Int32Value( 5 )]
      public Int32 Int32Value4
      {
         get;
         private set;
      }

      [Int32Value( 6, Optional = true )]
      public Int32 Int32Value5
      {
         get;
         private set;
      }

      [Switch( "-", "foo", Ordinal = 4 )]
      public bool Switch1
      {
         get;
         private set;
      }
   }

   public class IllegalSwitchTypeArguments
   {
      [Switch( "-", "foo" )]
      public string Switch
      {
         get;
         private set;
      }
   }

   public class IllegalStringTypeArguments
   {
      [StringValue( 1 )]
      public Int32 Value
      {
         get;
         private set;
      }
   }

   public class IllegalSByteValueTypeArguments
   {
      [SByteValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalInt16ValueTypeArguments
   {
      [Int16Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalInt32ValueTypeArguments
   {
      [Int32Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalInt64ValueTypeArguments
   {
      [Int64Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalByteValueTypeArguments
   {
      [ByteValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalUInt16ValueTypeArguments
   {
      [UInt16Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalUInt32ValueTypeArguments
   {
      [UInt32Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalUInt64ValueTypeArguments
   {
      [UInt64Value( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalSingleValueTypeArguments
   {
      [SingleValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalDoubleValueTypeArguments
   {
      [DoubleValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalDecimalValueTypeArguments
   {
      [DecimalValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class IllegalDateTimeValueTypeArguments
   {
      [DateTimeValue( 1 )]
      public string Value
      {
         get;
         private set;
      }
   }

   public class DescriptionArguments
   {
      [Int32Value( 1, Description = "This is an Int32 value." )]
      public Int32 Value
      {
         get;
         private set;
      }

      [Switch( "-", "foo", Description = "This is a switch." )]
      public bool Switch
      {
         get;
         private set;
      }
   }

   public class ValueSwitchGroupArguments
   {
      [StringValue( 1, Description = "String_1" )]
      public String String_1
      {
         get;
         private set;
      }

      [Int32Value( 2, Description = "Int32_1" )]
      public Int32 Int32_1
      {
         get;
         private set;
      }

      [Switch( "-", "foo", Optional = true, Groups = new int[] { 1 }, Description = "foo" )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( "-", "bar", Optional = true, Groups = new int[] { 2 }, Description = "bar" )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class CompoundArguments
   {
      [Int32Compound( "-", "foo", Ordinal = 1, AcceptableValues = new int[] { 1, 2, 3 } )]
      public Int32 Foo
      {
         get;
         private set;
      }

      [StringCompound( "-", "bar", Ordinal = 2, AcceptableValues = new string[] { "Red", "White", "Blue" } )]
      public String Bar
      {
         get;
         private set;
      }
   }

   public class InvalidInt32CompoundArguments
   {
      [Int32Compound( "-", "foo", Ordinal = 1, AcceptableValues = new int[] { 1, 2, 3 } )]
      public String Foo
      {
         get;
         private set;
      }
   }

   public class SamePrefixLabelSwitchArguments
   {
      [Switch( "-", "foo" )]
      public bool Switch1
      {
         get;
         private set;
      }

      [Switch( "-", "foo" )]
      public bool Switch2
      {
         get;
         private set;
      }
   }

   public class SamePrefixLabelCompoundArguments
   {
      [Int32Compound( "-", "foo" )]
      public Int32 Compound1
      {
         get;
         private set;
      }

      [Int32Compound( "-", "foo" )]
      public Int32 Compound2
      {
         get;
         private set;
      }
   }

   public class SamePrefixLabelSwitchCompoundArguments
   {
      [Int32Compound( "-", "foo" )]
      public Int32 Compound1
      {
         get;
         private set;
      }

      [Switch( "-", "foo" )]
      public bool Switch2
      {
         get;
         private set;
      }
   }

   public enum Shapes
   {
      Square,
      Circle,
      Triangle
   }

   public class EnumValueArguments
   {
      [EnumValue( 1 )]
      public Shapes Enum1
      {
         get;
         private set;
      }
   }

   public class InvalidEnumValueArguments
   {
      [EnumValue( 1 )]
      public String Enum1
      {
         get;
         private set;
      }
   }

   public class EnumCompoundArguments
   {
      [EnumCompound( "-", "foo" )]
      public Shapes Enum1
      {
         get;
         private set;
      }
   }

   public class InvalidEnumCompoundArguments
   {
      [EnumCompound( "-", "foo" )]
      public String Enum1
      {
         get;
         private set;
      }
   }

   public class FilePathValueArguments
   {
      [FilePath( 1 )]
      public String FilePath1
      {
         get;
         private set;
      }

      [FilePath( 2, MustExist = true )]
      public String FilePath2
      {
         get;
         private set;
      }
   }

   public class InvalidFilePathValueArguments
   {
      [FilePath( 1 )]
      public Int32 FilePath1
      {
         get;
         private set;
      }
   }

   public class FilePathCompoundArguments
   {
      [FilePathCompound( "-", "foo" )]
      public String FilePath1
      {
         get;
         private set;
      }

      [FilePathCompound( "-", "bar", MustExist = true )]
      public String FilePath2
      {
         get;
         private set;
      }
   }

   public class InvalidFilePathCompoundArguments
   {
      [FilePathCompound( "-", "foo" )]
      public Int32 FilePath1
      {
         get;
         private set;
      }
   }
}
