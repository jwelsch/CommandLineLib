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
   }
}
