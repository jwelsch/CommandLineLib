/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int32Compound : CompoundAttribute
   {
      public Int32Compound( string prefix, string label )
         : base( prefix, label, typeof( Int32 ) )
      {
         this.RangeMin = Int32.MinValue;
         this.RangeMax = Int32.MaxValue;
      }

      public Int32[] AcceptableValues
      {
         get;
         set;
      }

      public Int32 RangeMin
      {
         get;
         set;
      }

      public Int32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int32CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class Int32CompoundArgument :  CompoundRangeValueArgument<Int32>
   {
      public Int32CompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Int32[] acceptableValues, Int32 rangeMin, Int32 rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

