﻿using System;
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

   public class SimpleValueArgument
   {
      [Int32Value( 1 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class AcceptableValueArgument
   {
      [Int32Value( 1, AcceptableValues = new int[] { 1, 3, 5, 8 } )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class RangeValueArgument
   {
      [Int32Value( 1, RangeMax = 47, RangeMin = -3 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class InvalidRangeValueArgument
   {
      [Int32Value( 1, RangeMin = 47, RangeMax = -3 )]
      public Int32 Int32Value
      {
         get;
         private set;
      }
   }

   public class StringValueArgument
   {
      [StringValue( 1 )]
      public String StringValue
      {
         get;
         private set;
      }
   }

   public class AcceptableStringValueArgument
   {
      [StringValue( 1, AcceptableValues = new string[] { "foo", "bar" } )]
      public String StringValue
      {
         get;
         private set;
      }
   }

   public class MultipleValueArguments
   {
      [Int32Value( 6, RangeMin = 0, RangeMax = 10 )]
      public Int32 Int32Value4
      {
         get;
         private set;
      }

      [Int32Value( 5, RangeMax = 0 )]
      public Int32 Int32Value3
      {
         get;
         private set;
      }

      [Int32Value( 4, RangeMin = 0 )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }

      [Int32Value( 3, AcceptableValues = new int[] { -1, 0, 1 } )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }

      [StringValue( 1, AcceptableValues = new string[] { "foo", "bar" } )]
      public String StringValue1
      {
         get;
         private set;
      }

      [StringValue( 2 )]
      public String StringValue2
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "a" )]
      public bool Switch1
      {
         get;
         private set;
      }
   }

   public class MultipleOrdinalValueSwitchArguments
   {
      [Switch( Prefix = "-", Label = "red", Optional = true, Ordinal = 2 )]
      public bool Switch1
      {
         get;
         private set;
      }

      [Switch( Prefix = "-", Label = "blue", Optional = true, Ordinal = 2 )]
      public bool Switch2
      {
         get;
         private set;
      }

      [Int32Value( 2, Optional = true )]
      public Int32 Int32Value2
      {
         get;
         private set;
      }

      [StringValue( 3 )]
      public String StringValue1
      {
         get;
         private set;
      }

      [Int32Value( 1 )]
      public Int32 Int32Value1
      {
         get;
         private set;
      }
   }
}
