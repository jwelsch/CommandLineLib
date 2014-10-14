﻿using System;
using System.Reflection;

namespace CommandLineLib
{
   public class StringCompound : CompoundAttribute
   {
      public StringCompound( string prefix, string label )
         : base( prefix, label )
      {
      }

      public String[] AcceptableValues
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new StringCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label, this.AcceptableValues );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( String ) );
      }
   }
}