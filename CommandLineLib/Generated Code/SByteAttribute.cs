using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SByteValue : RangeValue
   {
      public SByteValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = SByte.MinValue;
         this.RangeMax = SByte.MaxValue;
      }

      public SByte[] AcceptableValues
      {
         get;
         set;
      }

      public SByte RangeMin
      {
         get;
         set;
      }

      public SByte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( SByte ) );
      }
   }

   public class SByteValueArgument : RangeValueArgument<SByte>
   {
      public SByteValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, SByte[] acceptableValues, SByte rangeMin, SByte rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

