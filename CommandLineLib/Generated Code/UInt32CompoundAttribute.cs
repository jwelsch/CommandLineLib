using System;
using System.Reflection;

namespace CommandLineLib
{
   public class UInt32Compound : CompoundAttribute
   {
      public UInt32Compound( string prefix, string label )
         : base( prefix, label )
      {
         this.RangeMin = UInt32.MinValue;
         this.RangeMax = UInt32.MaxValue;
      }

      public UInt32[] AcceptableValues
      {
         get;
         set;
      }

      public UInt32 RangeMin
      {
         get;
         set;
      }

      public UInt32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt32CompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt32 ) );
      }
   }

   public class UInt32CompoundArgument :  CompoundRangeValueArgument<UInt32>
   {
      public UInt32CompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, UInt32[] acceptableValues, UInt32 rangeMin, UInt32 rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

