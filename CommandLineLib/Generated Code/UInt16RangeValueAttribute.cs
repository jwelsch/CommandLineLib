/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt16Value : RangeValueBaseAttribute
   {
      public UInt16Value( int ordinal )
         : base( ordinal, typeof( UInt16 ) )
      {
         this.AcceptableValues = new UInt16[0];
         this.rangeMin = UInt16.MinValue;
         this.RangeMax = UInt16.MaxValue;
      }

      private UInt16[] acceptableValues;
      public UInt16[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<UInt16>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private UInt16 rangeMin;
      public UInt16 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<UInt16>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<UInt16>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private UInt16 rangeMax;
      public UInt16 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<UInt16>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<UInt16>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<UInt16>( (UInt16) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<UInt16>( (UInt16) value, this.AcceptableValues );
      }
   }

   public class UInt16Compound : UInt16Value, ICompoundAttribute
   {
      private CompoundManager manager;

      public UInt16Compound( string prefix, string label )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, prefix, label );
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         set { base.Ordinal = value; }
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.manager.CaseSensitive; }
         set { this.manager.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.manager.Prefix; }
      }

      public string Label
      {
         get { return this.manager.Label; }
      }

      public string[] Aliases
      {
         get { return this.manager.Aliases; }
         set { this.manager.Aliases = value; }
      }

      #endregion

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }
}

