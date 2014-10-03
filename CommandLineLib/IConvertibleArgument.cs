using System;

namespace CommandLineLib
{
   public interface IConvertibleArgument
   {
      object Convert( object value );
   }
}
