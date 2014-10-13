using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IBaseAttribute
   {
      /// <summary>
      /// <=0 is any order.
      /// >0 is ascending order.
      /// If no ordinal is specified, the default is 0.
      /// Can have multiple switch arguments with the same ordinal.  Those with
      /// the same ordinal can be in any order within that ordinal number.
      /// Only one argument (switch or value) can have a specific ordinal if
      /// that ordinal is assigned to a value argument.
      /// </summary>
      int Ordinal
      {
         get;
      }

      /// <summary>
      /// Switch arguments can be optional without restrictions.
      /// An optional value argument cannot be followed by any required
      /// parameters unless they are separated by a switch argument.  In this
      /// case the switch argument must have an ordinal.
      /// 
      /// Legal Example:
      ///   value1 (Ordinal = 1, Optional = false)
      ///   value2 (Ordinal = 2, Optional = true)
      ///   value3 (Ordinal = 3, Optional = true)
      ///   -a     (Ordinal = 4, Optional = false)
      ///   value4 (Ordinal = 5, Optional = false)
      /// 
      /// Illegal Example:
      ///   value1 (Ordinal = 1, Optional = false)
      ///   value2 (Ordinal = 2, Optional = true)
      ///   value3 (Ordinal = 3, Optional = false)
      /// </summary>
      bool Optional
      {
         get;
      }

      /// <summary>
      /// Can be any integer.  If zero is specified, the argument belongs to
      /// any group.
      /// If no group is specified the argument is assigned zero for a group
      /// and belongs to all groups.
      /// Can belong to multiple groups.
      /// Arguments in the same group are allowed to be specified together on
      /// the command line.  Arguments NOT in the same group are not allowed to
      /// be specified together on the command line.
      /// 
      /// Example:
      ///   -a (group 1)
      ///   -b (group 2)
      ///   -c (group 1)
      ///   -d (no group specified)
      ///   
      /// Allowed:
      ///   app.exe -a -c -d
      ///   
      /// Not allowed:
      ///   app.exe -a -b -d (because -a and -b belong to different groups).
      /// </summary>
      int[] Groups
      {
         get;
      }

      string Description
      {
         get;
      }

      IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
      bool CheckPropertyType( PropertyInfo propertyInfo );
   }

   public abstract class BaseAttribute : System.Attribute, IBaseAttribute
   {
      public BaseAttribute()
      {
         this.Groups = new int[] { 0 };
      }

      private int ordinal;
      public int Ordinal
      {
         get { return this.ordinal; }
         set { this.ordinal = ( value < 0 ? 0 : value ); }
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

      public abstract IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
      public abstract bool CheckPropertyType( PropertyInfo propertyInfo );
   }

   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   //public class Compound : ICompoundAttribute
   //{
   //   private Switch @switch;
   //   private Type valueType;

   //   public Compound( string prefix, string label )
   //   {
   //      this.@switch = new Switch( prefix, label );
   //   }

   //   public bool CaseSensitive
   //   {
   //      get { return this.@switch.CaseSensitive; }
   //      set { this.@switch.CaseSensitive = value; }
   //   }

   //   public string Prefix
   //   {
   //      get { return this.@switch.Prefix; }
   //   }

   //   public string Label
   //   {
   //      get { return this.@switch.Label; }
   //   }

   //   public override string Description
   //   {
   //      get { return this.@switch.Description; }
   //   }

   //   #region IBaseAttribute Members

   //   public int Ordinal
   //   {
   //      get { return this.@switch.Ordinal; }
   //   }

   //   public bool Optional
   //   {
   //      get { return this.@switch.Optional; }
   //   }

   //   public int[] Groups
   //   {
   //      get { return this.@switch.Groups; }
   //   }

   //   #endregion
   //}
}