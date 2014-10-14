using System;
using System.Reflection;

namespace CommandLineLib
{
   public class EnumValue : BaseAttribute
   {
      private Type enumType;

      public EnumValue( int ordinal )
      {
         this.Ordinal = ordinal;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         private set { base.Ordinal = value; }
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         var argumentType = typeof( EnumArgument<> ).MakeGenericType( this.enumType );
         return (IBaseArgument) Activator.CreateInstance( argumentType, new object[] { new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description } );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         if ( !propertyInfo.PropertyType.IsEnum )
         {
            return false;
         }

         this.enumType = propertyInfo.PropertyType;
         return true;
      }
   }
}
