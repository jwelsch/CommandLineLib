/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt16Compound : CompoundAttribute
   {
      public UInt16Compound( string prefix, string label )
         : base( prefix, label, typeof( UInt16 ) )
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
         return new UInt16CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class UInt16CompoundArgument :  CompoundRangeValueArgument<UInt16>
   {
      public UInt16CompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, UInt16[] acceptableValues, UInt16 rangeMin, UInt16 rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

