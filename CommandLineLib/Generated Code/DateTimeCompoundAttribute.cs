using System;
using System.Reflection;

namespace CommandLineLib
{
   public class DateTimeCompound : CompoundAttribute
   {
      public DateTimeCompound( string prefix, string label )
         : base( prefix, label )
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
         return new DateTimeCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( DateTime ) );
      }
   }

   public class DateTimeCompoundArgument :  CompoundRangeValueArgument<DateTime>
   {
      public DateTimeCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, DateTime[] acceptableValues, DateTime rangeMin, DateTime rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

