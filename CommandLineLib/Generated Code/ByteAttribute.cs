using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ByteValue : RangeValue
   {
      public ByteValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Byte.MinValue;
         this.RangeMax = Byte.MaxValue;
      }

      public Byte[] AcceptableValues
      {
         get;
         set;
      }

      public Byte RangeMin
      {
         get;
         set;
      }

      public Byte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new ByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Byte ) );
      }
   }

   public class ByteValueArgument : RangeValueArgument<Byte>
   {
      public ByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

