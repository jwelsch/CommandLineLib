/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeValue : RangeValue
   {
      public DateTimeValue( int ordinal )
         : base( ordinal, typeof( DateTime ) )
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
         return new DateTimeValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DateTimeValueArgument : RangeValueArgument<DateTime>
   {
      public DateTimeValueArgument( PropertyAccessor property, IAttributeData attributeData, DateTime[] acceptableValues, DateTime rangeMin, DateTime rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

