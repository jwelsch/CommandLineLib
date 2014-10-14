/****************************************************************************\
*                                                                            *
*           THIS FILE WAS GENERATED AUTOMATICALLY!  DO NOT MODIFY!           *
*                                                                            *
\****************************************************************************/

using System;
using System.Reflection;

namespace CommandLineLib
{
   public class SByteCompound : CompoundAttribute
   {
      public SByteCompound( string prefix, string label )
         : base( prefix, label, typeof( SByte ) )
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
         return new SByteCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   public class SByteCompoundArgument :  CompoundRangeValueArgument<SByte>
   {
      public SByteCompoundArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, bool caseSensitive, string prefix, string label, SByte[] acceptableValues, SByte rangeMin, SByte rangeMax )
         : base( property, ordinal, optional, groups, description, caseSensitive, prefix, label, acceptableValues, rangeMin, rangeMax )
      {
      }
   }
}

