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

   public class SByteCompound : SByteValue, ICompoundAttribute
   {
      private CompoundManager manager;

      public SByteCompound( string prefix, string label )
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

