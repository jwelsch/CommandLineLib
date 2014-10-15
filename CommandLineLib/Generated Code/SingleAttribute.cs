/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SingleValue : RangeValue
   {
      public SingleValue( int ordinal )
         : base( ordinal, typeof( Single ) )
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
         return new SingleValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class SingleValueArgument : RangeValueArgument<Single>
   {
      public SingleValueArgument( PropertyAccessor property, IAttributeData attributeData, Single[] acceptableValues, Single rangeMin, Single rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

