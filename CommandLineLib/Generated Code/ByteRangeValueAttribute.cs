/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ByteValue : RangeValueBaseAttribute
   {
      public ByteValue( int ordinal )
         : base( ordinal, typeof( Byte ) )
      {
         this.AcceptableValues = new Byte[0];
         this.rangeMin = Byte.MinValue;
         this.RangeMax = Byte.MaxValue;
      }

      private Byte[] acceptableValues;
      public Byte[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            RangeValueHelper.CheckAcceptableValues<Byte>( value, this.RangeMin, this.RangeMax, true );

            this.acceptableValues = value;
         }
      }

      private Byte rangeMin;
      public Byte RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            RangeValueHelper.CheckRange<Byte>( value, this.RangeMax, true );
            RangeValueHelper.CheckAcceptableValues<Byte>( this.AcceptableValues, value, this.RangeMax, true );

            this.rangeMin = value;
         }
      }

      private Byte rangeMax;
      public Byte RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            RangeValueHelper.CheckRange<Byte>( this.RangeMin, value, true );
            RangeValueHelper.CheckAcceptableValues<Byte>( this.AcceptableValues, this.RangeMin, value, true );

            this.rangeMax = value;
         }
      }

      protected override bool IsInRange( object value )
      {
         return RangeValueHelper.IsInRange<Byte>( (Byte) value, this.RangeMin, this.RangeMax );
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<Byte>( (Byte) value, this.AcceptableValues );
      }
   }

   public class ByteCompound : ByteValue, ICompoundAttribute
   {
      private CompoundManager manager;

      public ByteCompound( string identifier )
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

