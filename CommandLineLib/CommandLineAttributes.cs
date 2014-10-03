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

      IArgumentPropertyBinding GetBinding( object argument, PropertyInfo property );
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

      public virtual IArgumentPropertyBinding GetBinding( object argument, PropertyInfo property )
      {
         return new ArgumentPropertyBinding( argument, property );
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

   public interface IValueArgument : IConvertibleArgument, IAcceptableArgument
   {
   }

   public abstract class Value : BaseArgument, IValueArgument
   {
      protected Type ArgumentType
      {
         get;
         set;
      }

      private MethodInfo parseMethodInfo;

      private object[] acceptableValues = new object[0];
      public virtual object[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set
         {
            this.CheckType( value );

            this.acceptableValues = value;
         }
      }

      public override string Description
      {
         get;
         set;
      }

      public override IArgumentPropertyBinding GetBinding( object argument, PropertyInfo property )
      {
         return new ValueArgumentPropertyBinding( argument, property, this, this );
      }

      protected void CheckType( object value )
      {
         if ( value.GetType() != this.ArgumentType )
         {
            throw new ArgumentTypeMismatchException( String.Format( "The parameter type \"{0}\" does match the value argument type \"{1}\".", value.GetType().Name, this.ArgumentType.Name ) );
         }
      }

      public object Convert( object value )
      {
         this.CheckType( value );

         if ( this.parseMethodInfo == null )
         {
            this.parseMethodInfo = this.ArgumentType.GetMethod( "Parse", BindingFlags.Static | BindingFlags.Public );
         }

         return this.parseMethodInfo.Invoke( null, new object[] { value } );
      }

      public bool IsAcceptable( object value )
      {
         this.CheckType( value );

         if ( ( this.AcceptableValues == null ) || ( this.AcceptableValues.Length == 0 ) )
         {
            return true;
         }

         return 0 < Array.IndexOf<object>( this.AcceptableValues, value );
      }
   }

   public abstract class RangeValue : Value, IRangeableArgument
   {
      public override IArgumentPropertyBinding GetBinding( object argument, PropertyInfo property )
      {
         return new RangeValueArgumentPropertyBinding( argument, property, this, this, this );
      }

      public bool IsInRange( object value )
      {
         this.CheckType( value );

         return value.InRange( this.RangeMin, this.RangeMax );
      }

      public override object[] AcceptableValues
      {
         set
         {
            foreach ( var item in value )
            {
               if ( !this.IsInRange( item ) )
               {
                  throw new ArgumentOutOfRangeException( "AcceptableValues", String.Format( "The value \"{0}\" in the AcceptedValues is out of the specified range ({1}, {2}).", item, this.RangeMin, this.RangeMax ) );
               }
            }

            base.AcceptableValues = value;
         }
      }

      private object rangeMin;
      public object RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            if ( value.IsGreater( this.RangeMax ) )
            {
               throw new ArgumentOutOfRangeException( "RangeMin", String.Format( "The minimum value of the range cannot be greater than the maximum value of the range." ) );
            }

            if ( this.AcceptableValues != null )
            {
               foreach ( var item in this.AcceptableValues )
               {
                  if ( !item.InRange( value, this.RangeMax ) )
                  {
                     throw new ArgumentOutOfRangeException( "RangeMin", String.Format( "The value \"{0}\" in the AcceptedValues would be out of the specified range ({1}, {2}).", item, value, this.RangeMax ) );
                  }
               }
            }

            this.rangeMin = value;
         }
      }

      private object rangeMax;
      public object RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            if ( value.IsLess( this.RangeMin ) )
            {
               throw new ArgumentOutOfRangeException( "RangeMax", String.Format( "The maximum value of the range cannot be less than the minimum value of the range." ) );
            }

            if ( this.AcceptableValues != null )
            {
               foreach ( var item in this.AcceptableValues )
               {
                  if ( !item.InRange( this.RangeMin, value ) )
                  {
                     throw new ArgumentOutOfRangeException( "RangeMax", String.Format( "The value \"{0}\" in the AcceptedValues would be out of the specified range ({1}, {2}).", item, this.RangeMin, value ) );
                  }
               }
            }

            this.rangeMax = value;
         }
      }
   }

   public class Int32Value : RangeValue
   {
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