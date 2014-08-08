using System;
using System.Reflection;

namespace CommandLineLib
{
   public class ArgumentInfo
   {
      public ArgumentInfo( IBaseArgument argument, ArgumentPropertyBinding property )
      {
         this.Argument = argument;
         this.Property = property;
      }

      public IBaseArgument Argument
      {
         get;
         private set;
      }

      public ArgumentPropertyBinding Property
      {
         get;
         private set;
      }
   }
}
