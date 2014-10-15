/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DecimalValue : RangeValue
   {
      public DecimalValue( int ordinal )
         : base( ordinal, typeof( Decimal ) )
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
         return new DecimalValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DecimalValueArgument : RangeValueArgument<Decimal>
   {
      public DecimalValueArgument( PropertyAccessor property, IAttributeData attributeData, Decimal[] acceptableValues, Decimal rangeMin, Decimal rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

