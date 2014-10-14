/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DecimalCompound : CompoundAttribute
   {
      public DecimalCompound( string prefix, string label )
         : base( prefix, label, typeof( Decimal ) )
      {
         this.RangeMin = Decimal.MinValue;
         this.RangeMax = Decimal.MaxValue;
      }

      public Decimal[] AcceptableValues
      {
         get;
         set;
      }

      public Decimal RangeMin
      {
         get;
         set;
      }

      public Decimal RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DecimalCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DecimalCompoundArgument :  CompoundRangeValueArgument<Decimal>
   {
      public DecimalCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, Decimal[] acceptableValues, Decimal rangeMin, Decimal rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

