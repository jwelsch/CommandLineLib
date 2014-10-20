using System;

namespace CommandLineLib
{
   public abstract class RangeValueBaseAttribute : AcceptableValueBaseAttribute, IRangeValueAttribute
   {
      public RangeValueBaseAttribute( int ordinal, Type valueType )
         : base( ordinal, valueType )
      {
      }

      protected override bool Validate( object convertedValue )
      {
         if ( !this.IsInRange( convertedValue ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is out of range for this argument \"{1}\".", convertedValue, this.ShortName ) );
         }

         return base.Validate( convertedValue );
      }

      protected abstract bool IsInRange( object value );
   }
}
