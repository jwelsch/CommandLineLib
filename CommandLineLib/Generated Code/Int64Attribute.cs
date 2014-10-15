/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Value : RangeValue
   {
      public Int64Value( int ordinal )
         : base( ordinal, typeof( Int64 ) )
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
         return new Int64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class Int64ValueArgument : RangeValueArgument<Int64>
   {
      public Int64ValueArgument( PropertyAccessor property, IAttributeData attributeData, Int64[] acceptableValues, Int64 rangeMin, Int64 rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

