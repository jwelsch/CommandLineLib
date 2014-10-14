using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int32Value : RangeValue
   {
      public Int32Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int32.MinValue;
         this.RangeMax = Int32.MaxValue;
      }

      public Int32[] AcceptableValues
      {
         get;
         set;
      }

      public Int32 RangeMin
      {
         get;
         set;
      }

      public Int32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int32 ) );
      }
   }

   public class Int32ValueArgument : RangeValueArgument<Int32>
   {
      public Int32ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Int32[] acceptableValues, Int32 rangeMin, Int32 rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

