using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt16Value : RangeValue
   {
      public UInt16Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt16.MinValue;
         this.RangeMax = UInt16.MaxValue;
      }

      public UInt16[] AcceptableValues
      {
         get;
         set;
      }

      public UInt16 RangeMin
      {
         get;
         set;
      }

      public UInt16 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt16 ) );
      }
   }
}

