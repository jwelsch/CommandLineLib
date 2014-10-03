using System;

namespace CommandLineLib
{
   public interface IAcceptableArgument
   {
      bool IsAcceptable( object value );
   }
}
