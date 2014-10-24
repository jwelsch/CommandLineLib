using System;

namespace CommandLineLib
{
   internal static class RangeValueHelper
   {
      public static bool CheckRange<T>( T rangeMin, T rangeMax, bool throwException = false )
      {
         if ( rangeMin.IsGreater( rangeMax ) )
         {
            if ( throwException )
            {
               throw new ArgumentOutOfRangeException( "rangeMin", String.Format( "The minimum value of the range cannot be greater than the maximum value of the range." ) );
            }

            return false;
         }

         if ( rangeMax.IsLess( rangeMin ) )
         {
            if ( throwException )
            {
               throw new ArgumentOutOfRangeException( "rangeMax", String.Format( "The maximum value of the range cannot be less than the minimum value of the range." ) );
            }

            return false;
         }

         return true;
      }

      public static bool CheckAcceptableValues<T>( T[] acceptableValues, T rangeMin, T rangeMax, bool throwException = false )
      {
         if ( acceptableValues != null )
         {
            foreach ( var value in acceptableValues )
            {
               if ( value.IsGreater( rangeMax ) || value.IsLess( rangeMin ) )
               {
                  if ( throwException )
                  {
                     throw new ArgumentOutOfRangeException( "acceptableValues", String.Format( "The value \"{0}\" in the accepted values would be out of the specified range ({1}, {2}).", value, rangeMin, rangeMax ) );
                  }

                  return false;
               }
            }
         }

         return true;
      }

      public static bool IsAcceptable<T>( T value, T[] acceptableValues )
      {
         if ( ( acceptableValues == null ) || ( acceptableValues.Length == 0 ) )
         {
            return true;
         }

         return ( 0 <= Array.IndexOf( acceptableValues, value ) );
      }

      public static bool IsInRange<T>( T value, T rangeMin, T rangeMax )
      {
         return ( ( value.IsGreater( rangeMin ) || value.Equals( rangeMin ) )
            && ( value.IsLess( rangeMax ) || value.Equals( rangeMax ) ) );
      }
   }
}
