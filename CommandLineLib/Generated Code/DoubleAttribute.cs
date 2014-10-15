/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DoubleValue : RangeValue
   {
      public DoubleValue( int ordinal )
         : base( ordinal, typeof( Double ) )
      {
         this.RangeMin = Double.MinValue;
         this.RangeMax = Double.MaxValue;
      }

      public Double[] AcceptableValues
      {
         get;
         set;
      }

      public Double RangeMin
      {
         get;
         set;
      }

      public Double RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DoubleValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DoubleValueArgument : RangeValueArgument<Double>
   {
      public DoubleValueArgument( PropertyAccessor property, IAttributeData attributeData, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

