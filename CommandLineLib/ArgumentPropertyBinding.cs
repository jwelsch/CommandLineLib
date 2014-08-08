using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ArgumentPropertyBinding
   {
      private object instance;
      private PropertyInfo property;

      public ArgumentPropertyBinding( object instance, PropertyInfo property )
      {
         this.instance = instance;
         this.property = property;
      }

      public object Value
      {
         get
         {
            return this.property.GetValue( this.instance );
         }
         set
         {
            this.WasSet = true;
            this.property.SetValue( this.instance, value );
         }
      }

      public bool WasSet
      {
         get;
         private set;
      }
   }
}
