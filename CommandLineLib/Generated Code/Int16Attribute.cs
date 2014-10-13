using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int16Value : RangeValue
   {
      public Int16Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int16.MinValue;
         this.RangeMax = Int16.MaxValue;
      }

      public Int16[] AcceptableValues
      {
         get;
         set;
      }

      public Int16 RangeMin
      {
         get;
         set;
      }

      public Int16 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int16 ) );
      }
   }
}

