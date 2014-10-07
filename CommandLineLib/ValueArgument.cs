using System;
using System.Reflection;

namespace CommandLineLib
{
   public abstract class ValueArgument<T> : BaseArgument
   {
      private MethodInfo parseMethodInfo = null;

      private T[] acceptableValues;
      protected virtual T[] AcceptableValues
      {
         get { return this.acceptableValues; }
         set { this.acceptableValues = value; }
      }

      public ValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, T[] acceptableValues )
         : base( property, ordinal, optional, groups, description )
      {
         this.acceptableValues = acceptableValues;
      }

      protected override object FromString( string value )
      {
         if ( this.parseMethodInfo == null )
         {
            this.parseMethodInfo = ( typeof( T ) ).GetMethod( "Parse", new Type[] { typeof( System.String ) } );

            if ( this.parseMethodInfo == null )
            {
               throw new NotImplementedException( String.Format( "The type \"{0}\" does not implement a \"Parse\" method.", typeof( T ).Name ) );
            }
         }

         return (T) this.parseMethodInfo.Invoke( null, new object[] { value } );
      }

      private bool IsAcceptable( T value )
      {
         if ( ( this.AcceptableValues == null ) || ( this.AcceptableValues.Length == 0 ) )
         {
            return true;
         }

         return ( 0 <= Array.IndexOf<T>( this.AcceptableValues, value ) );
      }

      public override void SetFromCommandLineArgument( string value )
      {
         var converted = (T) this.FromString( value );

         if ( !this.IsAcceptable( converted ) )
         {
            throw new UnacceptableArgumentException( String.Format( "The value \"{0}\" is not acceptable for this argument.", value ), value );
         }

         base.SetFromCommandLineArgument( value );
      }
   }
}
