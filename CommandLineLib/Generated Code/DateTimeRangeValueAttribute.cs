/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeValue : RangeValueBaseAttribute
   {
      public DateTimeValue( int ordinal )
         : base( ordinal, typeof( DateTime ) )
      {
         this.AcceptableValues = new DateTime[0];
         this.rangeMin = DateTime.MinValue;
         this.RangeMax = DateTime.MaxValue;
      }

      private DateTime[] acceptableValues;
      public DateTime[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<DateTime>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private DateTime rangeMin;
      public DateTime RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<DateTime>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<DateTime>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private DateTime rangeMax;
      public DateTime RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<DateTime>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<DateTime>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<DateTime>( (DateTime) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<DateTime>( (DateTime) value, this.AcceptableValues );
      }
   }
}