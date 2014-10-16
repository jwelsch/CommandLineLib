using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IBaseValueAttribute : IBaseAttribute
   {
   }

   public abstract class BaseValue : BaseAttribute, IBaseValueAttribute
   {
      protected Type ValueType
      {
         get;
         set;
      }

      public BaseValue( Type valueType )
      {
         this.ValueType = valueType;
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( this.ValueType == propertyInfo.PropertyType );
      }

      public override string Usage()
      {
         return "<" + this.ShortName + ">";
      }
   }

   public interface IValueAttribute : IBaseValueAttribute
   {
      new int Ordinal
      {
         get;
      }
   }

   public abstract class Value : BaseValue, IValueAttribute
   {
      public Value( int ordinal, Type valueType )
         : base( valueType )
      {
         this.Ordinal = ordinal;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         private set { base.Ordinal = value; }
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         var argumentType = typeof( ValueArgument<> ).MakeGenericType( this.ValueType );
         return (IBaseArgument) Activator.CreateInstance( argumentType, new object[] { new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description } );
      }
   }

   public interface IRangeValueAttribute : IValueAttribute
   {
   }

   public abstract class RangeValue : Value, IRangeValueAttribute
   {
      public RangeValue( int ordinal, Type valueType )
         : base( ordinal, valueType )
      {
      }
   }
}