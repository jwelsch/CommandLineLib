using System;
using System.Reflection;
using System.Collections.Generic;

namespace CommandLineLib
{
   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   public abstract class CompoundAttribute : BaseAttribute, ICompoundAttribute
   {
      private Type valueType;

      public CompoundAttribute( string prefix, string label, Type valueType )
      {
         this.Prefix = prefix;
         this.Label = label;
         this.valueType = valueType;
      }

      #region ISwitchAttribute Members

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

      #endregion

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( this.valueType == propertyInfo.PropertyType );
      }

      public override string ToString()
      {
         return this.Prefix + this.Label;
      }
   }
}
