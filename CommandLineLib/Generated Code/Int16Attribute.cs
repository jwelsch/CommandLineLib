/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int16Value : RangeValue
   {
      public Int16Value( int ordinal )
         : base( ordinal, typeof( Int16 ) )
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
         return new Int16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class Int16ValueArgument : RangeValueArgument<Int16>
   {
      public Int16ValueArgument( PropertyAccessor property, IAttributeData attributeData, Int16[] acceptableValues, Int16 rangeMin, Int16 rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

