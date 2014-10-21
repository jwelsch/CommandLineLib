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

   public class UInt32Compound : UInt32Value, ICompoundAttribute
   {
      private CompoundManager manager;

      public UInt32Compound( string identifier )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, identifier );
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

      public string Identifier
      {
         get { return this.manager.Identifier; }
      }

      public string[] Aliases
      {
         get { return this.manager.Aliases; }
         set { this.manager.Aliases = value; }
      }

      #endregion

      public override string ShortName
      {
         get { return this.manager.ShortName; }
         set { this.manager.ShortName = value; }
      }

      public override string UsageText
      {
         get { return this.manager.UsageText(); }
      }

      public override void SetProperty( PropertyInfo property )
      {
         this.manager.SetValueName( property.Name );
         base.SetProperty( property );
      }

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }
}

