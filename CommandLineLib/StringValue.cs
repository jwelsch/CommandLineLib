using System;
using System.Reflection;

namespace CommandLineLib
{
   public class StringValue : Value
   {
      public StringValue( int ordinal )
         : base( ordinal )
      {
      }

      public String[] AcceptableValues
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new StringValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( String ) );
      }
   }
}