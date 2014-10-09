using System;
using System.Reflection;

namespace CommandLineLib
{
   public class AttibutePropertyPair
   {
      public IBaseAttribute Attribute
      {
         get;
         private set;
      }

      public PropertyInfo Property
      {
         get;
         private set;
      }

      public AttibutePropertyPair( IBaseAttribute attribute, PropertyInfo property )
      {
         this.Attribute = attribute;
         this.Property = property;
      }
   }
}
