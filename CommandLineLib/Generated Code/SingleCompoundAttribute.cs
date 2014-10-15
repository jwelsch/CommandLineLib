/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SingleCompound : CompoundAttribute
   {
      public SingleCompound( string prefix, string label )
         : base( prefix, label, typeof( Single ) )
      {
         this.RangeMin = Single.MinValue;
         this.RangeMax = Single.MaxValue;
      }

      public Single[] AcceptableValues
      {
         get;
         set;
      }

      public Single RangeMin
      {
         get;
         set;
      }

      public Single RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SingleCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class SingleCompoundArgument :  CompoundRangeValueArgument<Single>
   {
      public SingleCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Single[] acceptableValues, Single rangeMin, Single rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

