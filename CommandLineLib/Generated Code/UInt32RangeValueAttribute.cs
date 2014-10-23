/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt32Value : RangeValueBaseAttribute
   {
      public UInt32Value( int ordinal )
         : base( ordinal, typeof( UInt32 ) )
      {
         this.AcceptableValues = new UInt32[0];
         this.rangeMin = UInt32.MinValue;
         this.RangeMax = UInt32.MaxValue;
      }

      private UInt32[] acceptableValues;
      public UInt32[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<UInt32>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private UInt32 rangeMin;
      public UInt32 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<UInt32>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<UInt32>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private UInt32 rangeMax;
      public UInt32 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<UInt32>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<UInt32>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<UInt32>( (UInt32) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<UInt32>( (UInt32) value, this.AcceptableValues );
      }
   }
}