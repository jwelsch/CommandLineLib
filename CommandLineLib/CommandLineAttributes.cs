using System;
using System.Reflection;
using System.Runtime.CompilerServices;

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

      IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
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
         set
         {
            if ( value < 0 )
            {
               this.ordinal = 0;
            }
            else
            {
               this.ordinal = value;
            }
         }
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
   }

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

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SwitchArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label );
      }
   }

   public interface IValueAttribute : IBaseAttribute
   {
   }

   public abstract class Value : BaseAttribute, IValueAttribute
   {
      public Value( int ordinal )
      {
         this.Ordinal = ordinal;
      }
   }

   public class StringValue : Value
   {
      public StringValue( int ordinal )
         : base( ordinal )
      {
      }

      public String[] AcceptableValues
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new StringValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues );
      }
   }

   public interface IRangeValueAttribute : IValueAttribute
   {
   }

   public abstract class RangeValue : Value, IRangeValueAttribute
   {
      public RangeValue( int ordinal )
         : base( ordinal )
      {
      }
   }

   public class Int32Value : RangeValue
   {
      public Int32Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int32.MinValue;
         this.RangeMax = Int32.MaxValue;
      }

      public Int32[] AcceptableValues
      {
         get;
         set;
      }

      public Int32 RangeMin
      {
         get;
         set;
      }

      public Int32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }
   }

   //public interface ICompoundArgument<V> : ISwitchArgument, IValueArgument<V>
   //{
   //}

   //public class Compound<V> : BaseArgument, ICompoundArgument<V>
   //{
   //   private Switch @switch = new Switch();
   //   private Value<V> value = new Value<V>();

   //   public bool CaseSensitive
   //   {
   //      get { return this.@switch.CaseSensitive; }
   //      set { this.@switch.CaseSensitive = value; }
   //   }

   //   public string Prefix
   //   {
   //      get { return this.@switch.Prefix; }
   //      set { this.@switch.Prefix = value; }
   //   }

   //   public string Label
   //   {
   //      get { return this.@switch.Label; }
   //      set { this.@switch.Label = value; }
   //   }

   //   public override string Description
   //   {
   //      get { return this.@switch.Description; }
   //   }
   //}
}