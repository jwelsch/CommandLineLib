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

      public ValueArgument( PropertyAccessor property, IAttributeData attributeData, T[] acceptableValues )
         : base( property, attributeData )
      {
         this.acceptableValues = acceptableValues;
      }

      protected virtual object FromString( string value )
      {
         if ( this.parseMethodInfo == null )
         {
            this.parseMethodInfo = ( typeof( T ) ).GetMethod( "TryParse", new Type[] { typeof( System.String ), typeof( T ).MakeByRefType() } );

            if ( this.parseMethodInfo == null )
            {
               return null;
            }
         }

         T converted = default( T );
         var args = new object[] { value, converted };
         var result = this.parseMethodInfo.Invoke( null, args );

         if ( ! (bool) result )
         {
            return null;
         }

         return args[1];
      }

      protected bool IsAcceptable( T value )
      {
         if ( ( this.AcceptableValues == null ) || ( this.AcceptableValues.Length == 0 ) )
         {
            return true;
         }

         return ( 0 <= Array.IndexOf<T>( this.AcceptableValues, value ) );
      }

      public override bool MatchCommandLineArgument( string value )
      {
         var converted = this.FromString( value );

         return ( converted != null );
      }

      public override void SetFromCommandLineArgument( string value )
      {
         var result = this.FromString( value );

         if ( result == null )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" could not be converted to type \"{1}\".", value, typeof( T ).Name ) );
         }

         var converted = (T) result;

         if ( !this.IsAcceptable( converted ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is not acceptable for this argument.", value ) );
         }

         this.Property.SetValue( converted );
      }
   }
}
