/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ByteValue : RangeValue
   {
      public ByteValue( int ordinal )
         : base( ordinal, typeof( Byte ) )
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
         return new ByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class ByteValueArgument : RangeValueArgument<Byte>
   {
      public ByteValueArgument( PropertyAccessor property, IAttributeData attributeData, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

