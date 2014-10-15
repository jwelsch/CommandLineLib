/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ByteCompound : CompoundAttribute
   {
      public ByteCompound( string prefix, string label )
         : base( prefix, label, typeof( Byte ) )
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
         return new ByteCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class ByteCompoundArgument :  CompoundRangeValueArgument<Byte>
   {
      public ByteCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label, Byte[] acceptableValues, Byte rangeMin, Byte rangeMax )
         : base( property, attributeData, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

