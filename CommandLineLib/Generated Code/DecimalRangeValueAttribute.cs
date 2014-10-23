/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DecimalValue : RangeValueBaseAttribute
   {
      public DecimalValue( int ordinal )
         : base( ordinal, typeof( Decimal ) )
      {
         this.AcceptableValues = new Decimal[0];
         this.rangeMin = Decimal.MinValue;
         this.RangeMax = Decimal.MaxValue;
      }

      private Decimal[] acceptableValues;
      public Decimal[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Decimal>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Decimal rangeMin;
      public Decimal RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Decimal>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Decimal>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Decimal rangeMax;
      public Decimal RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Decimal>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Decimal>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Decimal>( (Decimal) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Decimal>( (Decimal) value, this.AcceptableValues );
      }
   }
}