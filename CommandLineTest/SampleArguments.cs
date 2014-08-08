using System;
using CommandLineLib;

namespace CommandLineTest
{
   public class SingleSwitchArguments
   {
      [Switch( CaseSensitive = true, Prefix = "-", Label = "foo", Optional = false )]
      public bool Foo
      {
         get;
         private set;
      }
   }

   public class DoubleSwitchArguments
   {
      [Switch( CaseSensitive = true, Prefix = "-", Label = "foo", Optional = true )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( CaseSensitive = true, Prefix = "-", Label = "bar", Optional = true )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class MandatorySwitchArguments
   {
      [Switch( CaseSensitive = true, Prefix = "-", Label = "foo", Optional = false )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( CaseSensitive = true, Prefix = "-", Label = "bar", Optional = true )]
      public bool Bar
      {
         get;
         private set;
      }
   }
}
