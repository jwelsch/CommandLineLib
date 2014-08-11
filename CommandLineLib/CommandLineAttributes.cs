using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IBaseArgument
   {
      /// <summary>
      /// <=0 is any order.
      /// >0 is ascending order.
      /// If no ordinal is specified, the default is 0.
      /// Can have multiple arguments with the same ordinal.  Those with the
      /// same ordinal can be in any order within that ordinal number.
      /// </summary>
      int Ordinal
      {
         get;
      }

      bool Optional
      {
         get;
      }

      /// <summary>
      /// Can be any integer.
      /// Can belong to multiple groups.
      /// If no group is specified, the default is to only belong to the 0
      /// group.
      /// Arguments in the same group are allowed to be specified together on
      /// the command line.  Arguments NOT in the same group are not allowed to
      /// be specified together on the command line.
      /// 
      /// Example:
      ///   -a (group 1)
      ///   -b (group 2)
      ///   -c (group 1)
      ///   
      /// Allowed:
      ///   app.exe -a -c
      ///   
      /// Not allowed:
      ///   app.exe -a -b
      /// </summary>
      int[] Groups
      {
         get;
      }

      string Description
      {
         get;
      }
   }

   public abstract class BaseArgument : System.Attribute, IBaseArgument
   {
      public BaseArgument()
      {
         this.Groups = new int[] { 0 };
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

      public int[] Groups
      {
         get;
         set;
      }

      public virtual string Description
      {
         get;
         set;
      }
   }

   public interface ISwitchArgument : IBaseArgument
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

   public class Switch : BaseArgument, ISwitchArgument
   {
      public bool CaseSensitive
      {
         get;
         set;
      }

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

      public override string Description
      {
         get { return this.Prefix + this.Label; }
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

      public override string Description
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
      private Switch @switch = new Switch();
      private Value value = new Value();

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
         set { this.@switch.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.@switch.Prefix; }
         set { this.@switch.Prefix = value; }
      }

      public string Label
      {
         get { return this.@switch.Label; }
         set { this.@switch.Label = value; }
      }

      public string[] AcceptableValues
      {
         get { return this.value.AcceptableValues; }
         set { this.value.AcceptableValues = value; }
      }

      public override string Description
      {
         get { return this.@switch.Description; }
      }
   }
}