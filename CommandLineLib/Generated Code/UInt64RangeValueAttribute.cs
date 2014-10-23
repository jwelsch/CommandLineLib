/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt64Value : RangeValueBaseAttribute
   {
      public UInt64Value( int ordinal )
         : base( ordinal, typeof( UInt64 ) )
      {
         this.AcceptableValues = new UInt64[0];
         this.rangeMin = UInt64.MinValue;
         this.RangeMax = UInt64.MaxValue;
      }

      private UInt64[] acceptableValues;
      public UInt64[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<UInt64>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private UInt64 rangeMin;
      public UInt64 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<UInt64>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<UInt64>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private UInt64 rangeMax;
      public UInt64 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<UInt64>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<UInt64>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<UInt64>( (UInt64) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<UInt64>( (UInt64) value, this.AcceptableValues );
      }
   }
}