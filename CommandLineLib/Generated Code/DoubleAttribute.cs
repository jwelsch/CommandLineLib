using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DoubleValue : RangeValue
   {
      public DoubleValue( int ordinal )
         : base( ordinal )
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
         return new DoubleValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Double ) );
      }
   }

   public class DoubleValueArgument : RangeValueArgument<Double>
   {
      public DoubleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Double[] acceptableValues, Double rangeMin, Double rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

