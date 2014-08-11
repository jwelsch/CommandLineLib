using System;
using CommandLineLib;

namespace CommandLineTest
{
   public class SingleSwitchArguments
   {
      [Switch( Prefix = "-", Label = "foo" )]
      public bool Foo
      {
         get;
         private set;
      }
   }

   public class DoubleSwitchArguments
   {
      [Switch( Prefix = "-", Label = "foo" )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "bar" )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class OptionalSwitchArguments
   {
      [Switch( Prefix = "-", Label = "foo", Optional = true )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "bar", Optional = true )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class CaseSensitiveSwitchArguments
   {
      [Switch( CaseSensitive = true, Prefix = "-", Label = "foo" )]
      public bool Foo
      {
         get;
         private set;
      }

      [Switch( CaseSensitive = false, Prefix = "-", Label = "bar" )]
      public bool Bar
      {
         get;
         private set;
      }
   }

   public class OrdinalSwitchArguments
   {
      [Switch( Prefix = "-", Label = "red", Ordinal = 1 )]
      public bool Red
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "green", Ordinal = -1 )]
      public bool Green
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "blue", Ordinal = 2 )]
      public bool Blue
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "black", Ordinal = 1 )]
      public bool Black
      {
         get;
         private set;
      }
   }

   public class GroupSwitchArguments
   {
      [Switch( Prefix = "-", Label = "red", Groups = new int[] { 1, 2 } )]
      public bool Red
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "green", Groups = new int[] { 2, 3 } )]
      public bool Green
      {
         get;
         private set;
      }

      [Switch( Optional = true, Prefix = "-", Label = "blue", Groups = new int[] { 3 } )]
      public bool Blue
      {
         get;
         private set;
      }
   }
}
