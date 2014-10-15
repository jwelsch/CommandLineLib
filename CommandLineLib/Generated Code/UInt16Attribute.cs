/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt16Value : RangeValue
   {
      public UInt16Value( int ordinal )
         : base( ordinal, typeof( UInt16 ) )
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
         return new UInt16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class UInt16ValueArgument : RangeValueArgument<UInt16>
   {
      public UInt16ValueArgument( PropertyAccessor property, IAttributeData attributeData, UInt16[] acceptableValues, UInt16 rangeMin, UInt16 rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

