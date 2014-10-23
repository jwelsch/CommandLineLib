/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SingleValue : RangeValueBaseAttribute
   {
      public SingleValue( int ordinal )
         : base( ordinal, typeof( Single ) )
      {
         this.AcceptableValues = new Single[0];
         this.rangeMin = Single.MinValue;
         this.RangeMax = Single.MaxValue;
      }

      private Single[] acceptableValues;
      public Single[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Single>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Single rangeMin;
      public Single RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Single>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Single>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Single rangeMax;
      public Single RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Single>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Single>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Single>( (Single) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Single>( (Single) value, this.AcceptableValues );
      }
   }
}