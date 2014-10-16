using System;
using System.Reflection;

namespace CommandLineLib
{
   public class EnumValue : Value
   {
      public EnumValue( int ordinal )
         : base( ordinal, typeof( Type ) )
      {
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         var argumentType = typeof( EnumArgument<> ).MakeGenericType( this.ValueType );
         return (IBaseArgument) Activator.CreateInstance( argumentType, new object[] { new PropertyAccessor( instance, propertyInfo ), this } );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         if ( !propertyInfo.PropertyType.IsEnum )
         {
            return false;
         }

         this.ValueType = propertyInfo.PropertyType;
         return true;
      }
   }
}
