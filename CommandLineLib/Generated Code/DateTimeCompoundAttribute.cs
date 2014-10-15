/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeCompound : CompoundAttribute
   {
      public DateTimeCompound( string prefix, string label )
         : base( prefix, label, typeof( DateTime ) )
      {
         this.RangeMin = DateTime.MinValue;
         this.RangeMax = DateTime.MaxValue;
      }

      public DateTime[] AcceptableValues
      {
         get;
         set;
      }

      public DateTime RangeMin
      {
         get;
         set;
      }

      public DateTime RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DateTimeCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class DateTimeCompoundArgument :  CompoundRangeValueArgument<DateTime>
   {
      public DateTimeCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, DateTime[] acceptableValues, DateTime rangeMin, DateTime rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

