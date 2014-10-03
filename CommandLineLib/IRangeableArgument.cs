using System;

namespace CommandLineLib
{
   public interface IRangeableArgument
   {
      bool IsInRange( object value );
   }
}
