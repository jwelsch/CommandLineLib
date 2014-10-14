using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IValueAttribute : IBaseAttribute
   {
   }

   public abstract class Value : BaseAttribute, IValueAttribute
   {
      private Type valueType;

      public Value( int ordinal, Type valueType )
      {
         this.Ordinal = ordinal;
         this.valueType = valueType;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         private set { base.Ordinal = value; }
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         var argumentType = typeof( ValueArgument<> ).MakeGenericType( this.valueType );
         return (IBaseArgument) Activator.CreateInstance( argumentType, new object[] { new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description } );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( this.valueType == propertyInfo.PropertyType );
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