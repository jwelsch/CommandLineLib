using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface ISwitchAttribute : IBaseAttribute
   {
      bool CaseSensitive
      {
         get;
         set;
      }

      string Prefix
      {
         get;
      }

      string Label
      {
         get;
      }
   }

   public class Switch : BaseAttribute, ISwitchAttribute
   {
      public Switch( string prefix, string label )
      {
         this.Prefix = prefix;
         this.Label = label;
      }

      public bool CaseSensitive
      {
         get;
         set;
      }

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

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SwitchArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Boolean ) );
      }

      public override string ToString()
      {
         return this.Prefix + this.Label;
      }
   }
}