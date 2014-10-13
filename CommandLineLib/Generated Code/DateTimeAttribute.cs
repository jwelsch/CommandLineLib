using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeValue : RangeValue
   {
      public DateTimeValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = DateTime.MinValue;
         this.RangeMax = DateTime.MaxValue;
      }

      public DateTime[] AcceptableValues
      {
         get;
         set;
      }

      public DateTime RangeMin
      {
         get;
         set;
      }

      public DateTime RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DateTimeValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( DateTime ) );
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

