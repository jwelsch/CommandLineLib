using System;
using System.Reflection;

namespace CommandLineLib
{
   public class StringValue : Value
   {
      public StringValue( int ordinal )
         : base( ordinal, typeof( String ) )
      {
      }

      public String[] AcceptableValues
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new StringValueArgument( new PropertyAccessor( instance, propertyInfo ), this, this.AcceptableValues );
      }
   }
}