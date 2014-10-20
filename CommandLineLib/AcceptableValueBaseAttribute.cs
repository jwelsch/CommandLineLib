using System;

namespace CommandLineLib
{
   public abstract class AcceptableValueBaseAttribute : ValueBaseAttribute, IAcceptableValueAttribute
   {
      public AcceptableValueBaseAttribute( int ordinal, Type valueType )
         : base( ordinal, valueType )
      {
      }

      protected override bool Validate( object convertedValue )
      {
         if ( !this.IsAcceptable( convertedValue ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is not acceptable for this argument.", convertedValue ) );
         }

         return true;
      }

      protected abstract bool IsAcceptable( object value );
   }
}
