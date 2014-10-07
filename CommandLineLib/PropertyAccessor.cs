using System;
using System.Reflection;

namespace CommandLineLib
{
   public class PropertyAccessor
   {
      private PropertyInfo propertyInfo;
      private object instance;

      public PropertyAccessor( object instance, PropertyInfo propertyInfo )
      {
         this.instance = instance;
         this.propertyInfo = propertyInfo;
      }

      public void SetValue( object value )
      {
         this.propertyInfo.SetValue( instance, value );
         this.WasSet = true;
      }

      public object GetValue()
      {
         return this.propertyInfo.GetValue( this.instance );
      }

      public bool WasSet
      {
         get;
         private set;
      }
   }
}
