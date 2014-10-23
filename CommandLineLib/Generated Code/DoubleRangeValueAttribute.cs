/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DoubleValue : RangeValueBaseAttribute
   {
      public DoubleValue( int ordinal )
         : base( ordinal, typeof( Double ) )
      {
         this.AcceptableValues = new Double[0];
         this.rangeMin = Double.MinValue;
         this.RangeMax = Double.MaxValue;
      }

      private Double[] acceptableValues;
      public Double[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Double>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Double rangeMin;
      public Double RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Double>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Double>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Double rangeMax;
      public Double RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Double>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Double>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Double>( (Double) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Double>( (Double) value, this.AcceptableValues );
      }
   }
}