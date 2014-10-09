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

   public class SByteValueArgument : RangeValueArgument<SByte>
   {
      public SByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, SByte[] acceptableValues, SByte rangeMin, SByte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class Int16ValueArgument : RangeValueArgument<Int16>
   {
      public Int16ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int16[] acceptableValues, Int16 rangeMin, Int16 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class Int32ValueArgument : RangeValueArgument<Int32>
   {
      public Int32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int32[] acceptableValues, Int32 rangeMin, Int32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class Int64ValueArgument : RangeValueArgument<Int64>
   {
      public Int64ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int64[] acceptableValues, Int64 rangeMin, Int64 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class ByteValueArgument : RangeValueArgument<Byte>
   {
      public ByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class UInt16ValueArgument : RangeValueArgument<UInt16>
   {
      public UInt16ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt16[] acceptableValues, UInt16 rangeMin, UInt16 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class UInt32ValueArgument : RangeValueArgument<UInt32>
   {
      public UInt32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt32[] acceptableValues, UInt32 rangeMin, UInt32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class UInt64ValueArgument : RangeValueArgument<UInt64>
   {
      public UInt64ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt64[] acceptableValues, UInt64 rangeMin, UInt64 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class SingleValueArgument : RangeValueArgument<Single>
   {
      public SingleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Single[] acceptableValues, Single rangeMin, Single rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class DoubleValueArgument : RangeValueArgument<Double>
   {
      public DoubleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class DecimalValueArgument : RangeValueArgument<Decimal>
   {
      public DecimalValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Decimal[] acceptableValues, Decimal rangeMin, Decimal rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }

   public class DateTimeValueArgument : RangeValueArgument<DateTime>
   {
      public DateTimeValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, DateTime[] acceptableValues, DateTime rangeMin, DateTime rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}