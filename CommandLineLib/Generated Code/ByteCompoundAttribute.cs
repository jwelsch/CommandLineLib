using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ByteCompound : CompoundAttribute
   {
      public ByteCompound( string prefix, string label )
         : base( prefix, label )
      {
         this.RangeMin = Byte.MinValue;
         this.RangeMax = Byte.MaxValue;
      }

      public Byte[] AcceptableValues
      {
         get;
         set;
      }

      public Byte RangeMin
      {
         get;
         set;
      }

      public Byte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new ByteCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Byte ) );
      }
   }

   public class ByteCompoundArgument :  CompoundRangeValueArgument<Byte>
   {
      public ByteCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

