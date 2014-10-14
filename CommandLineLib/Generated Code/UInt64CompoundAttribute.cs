using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt64Compound : CompoundAttribute
   {
      public UInt64Compound( string prefix, string label )
         : base( prefix, label )
      {
         this.RangeMin = UInt64.MinValue;
         this.RangeMax = UInt64.MaxValue;
      }

      public UInt64[] AcceptableValues
      {
         get;
         set;
      }

      public UInt64 RangeMin
      {
         get;
         set;
      }

      public UInt64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt64CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt64 ) );
      }
   }

   public class UInt64CompoundArgument :  CompoundRangeValueArgument<UInt64>
   {
      public UInt64CompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, UInt64[] acceptableValues, UInt64 rangeMin, UInt64 rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

