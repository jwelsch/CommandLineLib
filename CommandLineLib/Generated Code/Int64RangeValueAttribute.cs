/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Value : RangeValueBaseAttribute
   {
      public Int64Value( int ordinal )
         : base( ordinal, typeof( Int64 ) )
      {
         this.AcceptableValues = new Int64[0];
         this.rangeMin = Int64.MinValue;
         this.RangeMax = Int64.MaxValue;
      }

      private Int64[] acceptableValues;
      public Int64[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Int64>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Int64 rangeMin;
      public Int64 RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Int64>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Int64>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Int64 rangeMax;
      public Int64 RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Int64>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Int64>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Int64>( (Int64) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Int64>( (Int64) value, this.AcceptableValues );
      }
   }

   public class Int64Compound : Int64Value, ICompoundAttribute
   {
      private CompoundManager manager;

      public Int64Compound( string identifier )
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
      
      public string[] AllIdentifiers()
      {
         return this.manager.AllIdentifiers();
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