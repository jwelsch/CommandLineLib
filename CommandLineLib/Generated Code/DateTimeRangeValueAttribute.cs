/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeValue : RangeValueBaseAttribute
   {
      public DateTimeValue( int ordinal )
         : base( ordinal, typeof( DateTime ) )
      {
         this.AcceptableValues = new DateTime[0];
         this.rangeMin = DateTime.MinValue;
         this.RangeMax = DateTime.MaxValue;
      }

      private DateTime[] acceptableValues;
      public DateTime[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<DateTime>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private DateTime rangeMin;
      public DateTime RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<DateTime>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<DateTime>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private DateTime rangeMax;
      public DateTime RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<DateTime>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<DateTime>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<DateTime>( (DateTime) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<DateTime>( (DateTime) value, this.AcceptableValues );
      }
   }

   public class DateTimeCompound : DateTimeValue, ICompoundAttribute
   {
      private CompoundManager manager;

      public DateTimeCompound( string identifier )
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

