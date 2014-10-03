using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ArgumentInfo
   {
      public ArgumentInfo( IBaseArgument argument, IArgumentPropertyBinding property )
      {
         this.Argument = argument;
         this.Property = property;
      }

      public IBaseArgument Argument
      {
         get;
         private set;
      }

      public IArgumentPropertyBinding Property
      {
         get;
         private set;
      }
   }
}
