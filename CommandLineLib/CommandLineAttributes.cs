using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IBaseArgument
   {
      bool CaseSensitive
      {
         get;
         set;
      }

      int Ordinal
      {
         get;
         set;
      }

      bool Optional
      {
         get;
         set;
      }

      int Group
      {
         get;
         set;
      }

      string Description
      {
         get;
         set;
      }
   }

   public abstract class BaseArgument : System.Attribute, IBaseArgument
   {
      //public enum ArgumentType
      //{
      //   Switch,
      //   Raw,
      //   Compound
      //}

      //public ArgumentType ArgumentType
      //{
      //   get;
      //   set;
      //}

      public bool CaseSensitive
      {
         get;
         set;
      }

      public int Ordinal
      {
         get;
         set;
      }

      public bool Optional
      {
         get;
         set;
      }

      public int Group
      {
         get;
         set;
      }

      public abstract string Description
      {
         get;
         set;
      }
   }

   public interface ISwitchArgument : IBaseArgument
   {
      string Prefix
      {
         get;
         set;
      }

      string Label
      {
         get;
         set;
      }
   }

   public class Switch : BaseArgument, ISwitchArgument
   {
      public string Prefix
      {
         get;
         set;
      }

      public string Label
      {
         get;
         set;
      }

      public string Description
      {
         get { return this.Prefix + this.Label; }
         set { }
      }
   }

   public interface IValueArgument
   {
      string[] AcceptableValues
      {
         get;
         set;
      }
   }

   public class Value : BaseArgument, IValueArgument
   {
      public string[] AcceptableValues
      {
         get;
         set;
      }

      public string Description
      {
         get;
         set;
      }
   }

   public interface ICompoundArgument : ISwitchArgument, IValueArgument
   {
   }

   public class Compound : BaseArgument, ICompoundArgument
   {
      public string Prefix
      {
         get;
         set;
      }

      public string Label
      {
         get;
         set;
      }

      public string[] AcceptableValues
      {
         get;
         set;
      }

      public string Description
      {
         get { return this.Prefix + this.Label; }
         set { }
      }
   }
}