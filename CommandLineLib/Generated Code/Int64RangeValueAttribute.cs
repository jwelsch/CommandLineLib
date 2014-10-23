/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Value : RangeValueBaseAttribute
   {
      public Int64Value( int ordinal )
         : base( ordinal, typeof( Int64 ) )
      {
         this.AcceptableValues = new Int64[0];
         this.rangeMin = Int64.MinValue;
         this.RangeMax = Int64.MaxValue;
      }

      private Int64[] acceptableValues;
      public Int64[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Int64>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Int64 rangeMin;
      public Int64 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Int64>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Int64>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Int64 rangeMax;
      public Int64 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Int64>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Int64>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Int64>( (Int64) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Int64>( (Int64) value, this.AcceptableValues );
      }
   }
}