using System;

namespace CommandLineLib
{
   public interface IValueAttribute : IBaseAttribute
   {
   }

   public abstract class Value : BaseAttribute, IValueAttribute
   {
      public Value( int ordinal )
      {
         this.Ordinal = ordinal;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         private set { base.Ordinal = value; }
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
}