using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt32Value : RangeValue
   {
      public UInt32Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt32.MinValue;
         this.RangeMax = UInt32.MaxValue;
      }

      public UInt32[] AcceptableValues
      {
         get;
         set;
      }

      public UInt32 RangeMin
      {
         get;
         set;
      }

      public UInt32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt32 ) );
      }
   }

   public class UInt32ValueArgument : RangeValueArgument<UInt32>
   {
      public UInt32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, UInt32[] acceptableValues, UInt32 rangeMin, UInt32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

