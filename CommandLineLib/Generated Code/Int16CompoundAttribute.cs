/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int16Compound : CompoundAttribute
   {
      public Int16Compound( string prefix, string label )
         : base( prefix, label, typeof( Int16 ) )
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
         return new Int16CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class Int16CompoundArgument :  CompoundRangeValueArgument<Int16>
   {
      public Int16CompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Int16[] acceptableValues, Int16 rangeMin, Int16 rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

