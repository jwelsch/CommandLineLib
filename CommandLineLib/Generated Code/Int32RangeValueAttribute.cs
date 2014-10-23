/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int32Value : RangeValueBaseAttribute
   {
      public Int32Value( int ordinal )
         : base( ordinal, typeof( Int32 ) )
      {
         this.AcceptableValues = new Int32[0];
         this.rangeMin = Int32.MinValue;
         this.RangeMax = Int32.MaxValue;
      }

      private Int32[] acceptableValues;
      public Int32[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Int32>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Int32 rangeMin;
      public Int32 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Int32>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Int32>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Int32 rangeMax;
      public Int32 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Int32>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Int32>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Int32>( (Int32) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Int32>( (Int32) value, this.AcceptableValues );
      }
   }
}