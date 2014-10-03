using System;
using System.Linq;
using System.Collections.Generic;

namespace CommandLineLib
{
   public static class Extensions
   {
      public static List<T> Common<T>( this IEnumerable<T> collection1, IEnumerable<T> collection2 )
      {
         var result = new List<T>();

         foreach ( var item1 in collection1 )
         {
            if ( collection2.Contains<T>( item1 ) )
            {
               result.Add( item1 );
            }
         }

         return result;
      }

      public static bool InRange( this object value, object min, object max, bool minInclusive = true, bool maxInclusive = true )
      {
         if ( value.GetType() == typeof( SByte ) )
         {
            return ( (SByte) value ).InRange( (SByte) min, (SByte) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Byte ) )
         {
            return ( (Byte) value ).InRange( (Byte) min, (Byte) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Int16 ) )
         {
            return ( (Int16) value ).InRange( (Int16) min, (Int16) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( UInt16 ) )
         {
            return ( (UInt16) value ).InRange( (UInt16) min, (UInt16) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Int32 ) )
         {
            return ( (Int32) value ).InRange( (Int32) min, (Int32) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( UInt32 ) )
         {
            return ( (UInt32) value ).InRange( (UInt32) min, (UInt32) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Int64 ) )
         {
            return ( (Int64) value ).InRange( (Int64) min, (Int64) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( UInt64 ) )
         {
            return ( (UInt64) value ).InRange( (UInt64) min, (UInt64) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Single ) )
         {
            return ( (Single) value ).InRange( (Single) min, (Single) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Double ) )
         {
            return ( (Double) value ).InRange( (Double) min, (Double) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( Decimal ) )
         {
            return ( (Decimal) value ).InRange( (Decimal) min, (Decimal) max, minInclusive, maxInclusive );
         }

         if ( value.GetType() == typeof( DateTime ) )
         {
            return ( (DateTime) value ).InRange( (DateTime) min, (DateTime) max, minInclusive, maxInclusive );
         }

         throw new ArgumentException( String.Format( "The type \"{0}\" of the \"value\" argument is not supported by the InRange method.", value.GetType().Name ), "value" );
      }

      public static bool InRange( this SByte value, SByte min, SByte max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Int16 value, Int16 min, Int16 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Int32 value, Int32 min, Int32 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Int64 value, Int64 min, Int64 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Byte value, Byte min, Byte max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this UInt16 value, UInt16 min, UInt16 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this UInt32 value, UInt32 min, UInt32 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this UInt64 value, UInt64 min, UInt64 max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Single value, Single min, Single max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Double value, Double min, Double max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this Decimal value, Decimal min, Decimal max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool InRange( this DateTime value, DateTime min, DateTime max, bool minInclusive = true, bool maxInclusive = true )
      {
         return ( minInclusive ? value >= min : value > min ) && ( maxInclusive ? value <= max : value < max );
      }

      public static bool IsGreater( this object value, object than )
      {
         if ( value.GetType() == typeof( SByte ) )
         {
            return ( (SByte) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Int16 ) )
         {
            return ( (Int16) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Int32 ) )
         {
            return ( (Int32) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Int64 ) )
         {
            return ( (Int64) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Byte ) )
         {
            return ( (Byte) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( UInt16 ) )
         {
            return ( (UInt16) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( UInt32 ) )
         {
            return ( (UInt32) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( UInt64 ) )
         {
            return ( (UInt64) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Single ) )
         {
            return ( (Single) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Double ) )
         {
            return ( (Double) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( Decimal ) )
         {
            return ( (Decimal) value ).IsGreater( than );
         }

         if ( value.GetType() == typeof( DateTime ) )
         {
            return ( (DateTime) value ).IsGreater( than );
         }

         throw new ArgumentException( String.Format( "The type \"{0}\" of the \"value\" argument is not supported by the IsGreater method.", value.GetType().Name ), "value" );
      }

      public static bool IsGreater( this SByte value, SByte than )
      {
         return value > than;
      }

      public static bool IsGreater( this Int16 value, Int16 than )
      {
         return value > than;
      }

      public static bool IsGreater( this Int32 value, Int32 than )
      {
         return value > than;
      }

      public static bool IsGreater( this Int64 value, Int64 than )
      {
         return value > than;
      }

      public static bool IsGreater( this Byte value, Byte than )
      {
         return value > than;
      }

      public static bool IsGreater( this UInt16 value, UInt16 than )
      {
         return value > than;
      }

      public static bool IsGreater( this UInt32 value, UInt32 than )
      {
         return value > than;
      }

      public static bool IsGreater( this UInt64 value, UInt64 than )
      {
         return value > than;
      }

      public static bool IsGreater( this Single value, Single than )
      {
         return value > than;
      }

      public static bool IsGreater( this Double value, Double than )
      {
         return value > than;
      }

      public static bool IsGreater( this Decimal value, Decimal than )
      {
         return value > than;
      }

      public static bool IsGreater( this DateTime value, DateTime than )
      {
         return value > than;
      }

      public static bool IsLess( this object value, object than )
      {
         if ( value.GetType() == typeof( SByte ) )
         {
            return ( (SByte) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Int16 ) )
         {
            return ( (Int16) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Int32 ) )
         {
            return ( (Int32) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Int64 ) )
         {
            return ( (Int64) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Byte ) )
         {
            return ( (Byte) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( UInt16 ) )
         {
            return ( (UInt16) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( UInt32 ) )
         {
            return ( (UInt32) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( UInt64 ) )
         {
            return ( (UInt64) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Single ) )
         {
            return ( (Single) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Double ) )
         {
            return ( (Double) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( Decimal ) )
         {
            return ( (Decimal) value ).IsLess( than );
         }

         if ( value.GetType() == typeof( DateTime ) )
         {
            return ( (DateTime) value ).IsLess( than );
         }

         throw new ArgumentException( String.Format( "The type \"{0}\" of the \"value\" argument is not supported by the IsLess method.", value.GetType().Name ), "value" );
      }

      public static bool IsLess( this SByte value, SByte than )
      {
         return value > than;
      }

      public static bool IsLess( this Int16 value, Int16 than )
      {
         return value > than;
      }

      public static bool IsLess( this Int32 value, Int32 than )
      {
         return value > than;
      }

      public static bool IsLess( this Int64 value, Int64 than )
      {
         return value > than;
      }

      public static bool IsLess( this Byte value, Byte than )
      {
         return value > than;
      }

      public static bool IsLess( this UInt16 value, UInt16 than )
      {
         return value > than;
      }

      public static bool IsLess( this UInt32 value, UInt32 than )
      {
         return value > than;
      }

      public static bool IsLess( this UInt64 value, UInt64 than )
      {
         return value > than;
      }

      public static bool IsLess( this Single value, Single than )
      {
         return value > than;
      }

      public static bool IsLess( this Double value, Double than )
      {
         return value > than;
      }

      public static bool IsLess( this Decimal value, Decimal than )
      {
         return value > than;
      }

      public static bool IsLess( this DateTime value, DateTime than )
      {
         return value > than;
      }
   }
}
