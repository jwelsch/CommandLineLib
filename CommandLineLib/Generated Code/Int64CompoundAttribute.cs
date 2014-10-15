/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Compound : CompoundAttribute
   {
      public Int64Compound( string prefix, string label )
         : base( prefix, label, typeof( Int64 ) )
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
         return new Int64CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class Int64CompoundArgument :  CompoundRangeValueArgument<Int64>
   {
      public Int64CompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Int64[] acceptableValues, Int64 rangeMin, Int64 rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

