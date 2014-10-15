/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DoubleCompound : CompoundAttribute
   {
      public DoubleCompound( string prefix, string label )
         : base( prefix, label, typeof( Double ) )
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
         return new DoubleCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DoubleCompoundArgument :  CompoundRangeValueArgument<Double>
   {
      public DoubleCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

