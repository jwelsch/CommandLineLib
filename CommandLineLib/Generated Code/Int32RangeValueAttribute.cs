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

   public class Int32Compound : Int32Value, ICompoundAttribute
   {
      private CompoundManager manager;

      public Int32Compound( string identifier )
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
      }

      public override string UsageText
      {
         get
         {
            var s = base.ShortName;
            return this.manager.UsageText( s );
         }
      }

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }
}

