/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SByteValue : RangeValue
   {
      public SByteValue( int ordinal )
         : base( ordinal, typeof( SByte ) )
      {
         this.RangeMin = SByte.MinValue;
         this.RangeMax = SByte.MaxValue;
      }

      public SByte[] AcceptableValues
      {
         get;
         set;
      }

      public SByte RangeMin
      {
         get;
         set;
      }

      public SByte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class SByteValueArgument : RangeValueArgument<SByte>
   {
      public SByteValueArgument( PropertyAccessor property, IAttributeData attributeData, SByte[] acceptableValues, SByte rangeMin, SByte rangeMax )
         : base( property, attributeData, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

