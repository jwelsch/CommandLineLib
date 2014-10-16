using System;
using System.Reflection;
using System.Collections.Generic;

namespace CommandLineLib
{
   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   public abstract class CompoundAttribute : BaseValue, ICompoundAttribute
   {
      public CompoundAttribute( string prefix, string label, Type valueType )
         : base( valueType )
      {
         this.Prefix = prefix;
         this.Label = label;
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

      public override string Usage()
      {
         return this.Prefix + this.Label;
      }

      public override string ToString()
      {
         return this.Usage();
      }
   }
}
