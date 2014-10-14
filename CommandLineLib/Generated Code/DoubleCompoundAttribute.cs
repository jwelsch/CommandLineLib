using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DoubleCompound : CompoundAttribute
   {
      public DoubleCompound( string prefix, string label )
         : base( prefix, label )
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
         return new DoubleCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Double ) );
      }
   }

   public class DoubleCompoundArgument :  CompoundRangeValueArgument<Double>
   {
      public DoubleCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

