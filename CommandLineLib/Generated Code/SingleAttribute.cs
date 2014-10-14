using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SingleValue : RangeValue
   {
      public SingleValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Single.MinValue;
         this.RangeMax = Single.MaxValue;
      }

      public Single[] AcceptableValues
      {
         get;
         set;
      }

      public Single RangeMin
      {
         get;
         set;
      }

      public Single RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SingleValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Single ) );
      }
   }

   public class SingleValueArgument : RangeValueArgument<Single>
   {
      public SingleValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Single[] acceptableValues, Single rangeMin, Single rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

