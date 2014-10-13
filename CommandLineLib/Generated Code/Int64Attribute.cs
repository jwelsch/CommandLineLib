using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Value : RangeValue
   {
      public Int64Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int64.MinValue;
         this.RangeMax = Int64.MaxValue;
      }

      public Int64[] AcceptableValues
      {
         get;
         set;
      }

      public Int64 RangeMin
      {
         get;
         set;
      }

      public Int64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int64 ) );
      }
   }
}

