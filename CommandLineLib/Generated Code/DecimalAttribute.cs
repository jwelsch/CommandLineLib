using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DecimalValue : RangeValue
   {
      public DecimalValue( int ordinal )
         : base( ordinal )
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
         return new DecimalValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Decimal ) );
      }
   }

   public class DecimalValueArgument : RangeValueArgument<Decimal>
   {
      public DecimalValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Decimal[] acceptableValues, Decimal rangeMin, Decimal rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

