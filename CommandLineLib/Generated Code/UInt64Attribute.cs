using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt64Value : RangeValue
   {
      public UInt64Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt64.MinValue;
         this.RangeMax = UInt64.MaxValue;
      }

      public UInt64[] AcceptableValues
      {
         get;
         set;
      }

      public UInt64 RangeMin
      {
         get;
         set;
      }

      public UInt64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt64 ) );
      }
   }

   public class UInt64ValueArgument : RangeValueArgument<UInt64>
   {
      public UInt64ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt64[] acceptableValues, UInt64 rangeMin, UInt64 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

