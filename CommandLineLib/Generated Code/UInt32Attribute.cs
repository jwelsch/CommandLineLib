/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt32Value : RangeValue
   {
      public UInt32Value( int ordinal )
         : base( ordinal, typeof( UInt32 ) )
      {
         this.RangeMin = UInt32.MinValue;
         this.RangeMax = UInt32.MaxValue;
      }

      public UInt32[] AcceptableValues
      {
         get;
         set;
      }

      public UInt32 RangeMin
      {
         get;
         set;
      }

      public UInt32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class UInt32ValueArgument : RangeValueArgument<UInt32>
   {
      public UInt32ValueArgument( PropertyAccessor property, IAttributeData attributeData, UInt32[] acceptableValues, UInt32 rangeMin, UInt32 rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

