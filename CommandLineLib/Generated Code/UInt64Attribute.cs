/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt64Value : RangeValue
   {
      public UInt64Value( int ordinal )
         : base( ordinal, typeof( UInt64 ) )
      {
         this.RangeMin = UInt64.MinValue;
         this.RangeMax = UInt64.MaxValue;
      }

      public UInt64[] AcceptableValues
      {
         get;
         set;
      }

      public UInt64 RangeMin
      {
         get;
         set;
      }

      public UInt64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class UInt64ValueArgument : RangeValueArgument<UInt64>
   {
      public UInt64ValueArgument( PropertyAccessor property, IAttributeData attributeData, UInt64[] acceptableValues, UInt64 rangeMin, UInt64 rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

