/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SByteValue : RangeValueBaseAttribute
   {
      public SByteValue( int ordinal )
         : base( ordinal, typeof( SByte ) )
      {
         this.AcceptableValues = new SByte[0];
         this.rangeMin = SByte.MinValue;
         this.RangeMax = SByte.MaxValue;
      }

      private SByte[] acceptableValues;
      public SByte[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<SByte>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private SByte rangeMin;
      public SByte RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<SByte>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<SByte>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private SByte rangeMax;
      public SByte RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<SByte>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<SByte>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<SByte>( (SByte) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<SByte>( (SByte) value, this.AcceptableValues );
      }
   }
}