/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int16Value : RangeValueBaseAttribute
   {
      public Int16Value( int ordinal )
         : base( ordinal, typeof( Int16 ) )
      {
         this.AcceptableValues = new Int16[0];
         this.rangeMin = Int16.MinValue;
         this.RangeMax = Int16.MaxValue;
      }

      private Int16[] acceptableValues;
      public Int16[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Int16>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Int16 rangeMin;
      public Int16 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Int16>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Int16>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Int16 rangeMax;
      public Int16 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Int16>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Int16>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Int16>( (Int16) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Int16>( (Int16) value, this.AcceptableValues );
      }
   }
}