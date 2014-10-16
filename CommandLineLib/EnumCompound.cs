using System;
using System.Reflection;

namespace CommandLineLib
{
   public class EnumCompound : CompoundAttribute
   {
      public EnumCompound( string prefix, string label )
         : base( prefix, label, typeof( Enum ) )
      {
         this.Prefix = prefix;
         this.Label = label;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         var argumentType = typeof( EnumCompoundArgument<> ).MakeGenericType( this.ValueType );
         return (IBaseArgument) Activator.CreateInstance( argumentType, new object[] { new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label } );
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

      #region ISwitchAttribute Members

      public string Prefix
      {
         get;
         private set;
      }

      public string Label
      {
         get;
         private set;
      }

      public bool CaseSensitive
      {
         get;
         set;
      }

      #endregion
   }
}
