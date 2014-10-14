using System;
using System.Reflection;

namespace CommandLineLib
{
   public class Int64Compound : CompoundAttribute
   {
      public Int64Compound( string prefix, string label )
         : base( prefix, label )
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
         return new Int64CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int64 ) );
      }
   }

   public class Int64CompoundArgument :  CompoundRangeValueArgument<Int64>
   {
      public Int64CompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, Int64[] acceptableValues, Int64 rangeMin, Int64 rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

