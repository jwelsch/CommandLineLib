using System;
using System.Reflection;
using System.Collections.Generic;

namespace CommandLineLib
{
   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   public abstract class CompoundAttribute : ICompoundAttribute
   {
      private Switch @switch;

      public CompoundAttribute( string prefix, string label )
      {
         this.@switch = new Switch( prefix, label );
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
         set { this.@switch.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.@switch.Prefix; }
      }

      public string Label
      {
         get { return this.@switch.Label; }
      }

      #endregion

      #region IBaseAttribute Members

      public int Ordinal
      {
         get { return this.@switch.Ordinal; }
         set { this.@switch.Ordinal = value; }
      }

      public bool Optional
      {
         get { return this.@switch.Optional; }
         set { this.@switch.Optional = value; }
      }

      public int[] Groups
      {
         get { return this.@switch.Groups; }
         set { this.@switch.Groups = value; }
      }

      public string Description
      {
         get { return this.@switch.Description; }
         set { this.@switch.Description = value; }
      }

      public abstract IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
      public abstract bool CheckPropertyType( PropertyInfo propertyInfo );

      #endregion
   }
}
