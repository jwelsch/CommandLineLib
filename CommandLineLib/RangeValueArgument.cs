using System;
using System.Reflection;

namespace CommandLineLib
{
   public abstract class RangeValueArgument<T> : ValueArgument<T>
   {
      public RangeValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, T[] acceptableValues, T rangeMin, T rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
         this.rangeMin = rangeMin;
         this.RangeMax = rangeMax;
      }

      private bool IsInRange( T value )
      {
         return value.InRange( this.RangeMin, this.RangeMax );
      }

      protected override T[] AcceptableValues
      {
         set
         {
            if ( value != null )
            {
               foreach ( var item in value )
               {
                  if ( !this.IsInRange( item ) )
                  {
                     throw new ArgumentOutOfRangeException( "AcceptableValues", String.Format( "The value \"{0}\" in the AcceptedValues is out of the specified range ({1}, {2}).", item, this.RangeMin, this.RangeMax ) );
                  }
               }
            }

            base.AcceptableValues = value;
         }
      }

      private T rangeMin;
      protected T RangeMin
      {
         get { return this.rangeMin; }
         set
         {
            if ( value.IsGreater( this.RangeMax ) )
            {
               throw new ArgumentOutOfRangeException( "RangeMin", String.Format( "The minimum value of the range cannot be greater than the maximum value of the range." ) );
            }

            if ( base.AcceptableValues != null )
            {
               foreach ( var item in base.AcceptableValues )
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

      private T rangeMax;
      protected T RangeMax
      {
         get { return this.rangeMax; }
         set
         {
            if ( value.IsLess( this.RangeMin ) )
            {
               throw new ArgumentOutOfRangeException( "RangeMax", String.Format( "The maximum value of the range cannot be less than the minimum value of the range." ) );
            }

            if ( base.AcceptableValues != null )
            {
               foreach ( var item in base.AcceptableValues )
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

      public override void SetFromCommandLineArgument( string value )
      {
         var converted = (T) this.FromString( value );

         if ( !this.IsInRange( converted ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is out of range for this argument.", value ) );
         }

         base.SetFromCommandLineArgument( value );
      }
   }
}
