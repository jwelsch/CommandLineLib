using System;
using CommandLineLib;
using TestFramework;

namespace CommandLineTest
{
   public class CommandLineTests
   {
#if false
      [TestMethod]
      public void NoCommandLineAttributes()
      {
         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
            {
               var commandLine = new CommandLine<EmptyArguments>();
               commandLine.Parse( new string[] { } );
            } );
      }

      [TestMethod]
      public void SingleSwitch()
      {
         var commandLine = new CommandLine<SingleSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-foo" } );
         TestHelper.Expected<bool>( true, () =>
            {
               return arguments.Foo;
            } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-bar" } );
         } );
      }

      [TestMethod]
      public void DoubleSwitch()
      {
         var commandLine = new CommandLine<DoubleSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-foo", "-bar" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo", "-bar1" } );
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo1", "-bar" } );
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo1", "-bar1" } );
         } );
      }

      [TestMethod]
      public void DuplicateSwitch()
      {
         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            var commandLine = new CommandLine<DoubleSwitchArguments>();
            var arguments = commandLine.Parse( new string[] { "-foo", "-foo" } );
         } );
      }

      [TestMethod]
      public void DoubleOptionalSwitch()
      {
         var commandLine = new CommandLine<OptionalSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-foo", "-bar" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );

         arguments = commandLine.Parse( new string[] { "-foo", "-bar1" } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );

         arguments = commandLine.Parse( new string[] { "-foo1", "-bar" } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );

         arguments = commandLine.Parse( new string[] { "-foo1", "-bar1" } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );
      }

      [TestMethod]
      public void CaseSensitiveSwitch()
      {
         var commandLine = new CommandLine<CaseSensitiveSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-foo", "-bar" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-Foo", "-bar" } );
         } );

         arguments = commandLine.Parse( new string[] { "-foo", "-Bar" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo && arguments.Bar;
         } );
      }

      [TestMethod]
      public void OrdinalSwitch()
      {
         var commandLine = new CommandLine<OrdinalSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-red", "-green", "-black", "-blue" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Red && arguments.Green && arguments.Black && arguments.Blue;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-red", "-green", "-blue", "-black" } );
         } );
      }

      [TestMethod]
      public void GroupSwitch()
      {
         var commandLine = new CommandLine<GroupSwitchArguments>();
         var arguments = commandLine.Parse( new string[] { "-red", "-green" } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Red && arguments.Green && !arguments.Blue;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            arguments = commandLine.Parse( new string[] { "-red", "-green", "-blue" } );
         } );
      }

      [TestMethod]
      public void SimpleValueArgument()
      {
         var simpleValue = 29;

         var commandLine = new CommandLine<SimpleValueArgument>();
         var arguments = commandLine.Parse( new string[] { simpleValue.ToString() } );

         TestHelper.Expected<Int32>( simpleValue, () =>
            {
               return arguments.Int32Value;
            } );
      }

      [TestMethod]
      public void AcceptableValueArgument()
      {
         var acceptableValue = 3;
         var notAcceptableValue = 9;

         var commandLine = new CommandLine<AcceptableValueArgument>();

         var arguments = commandLine.Parse( acceptableValue.ToString() );
         TestHelper.Expected<Int32>( acceptableValue, () =>
         {
            return arguments.Int32Value;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
            {
               arguments = commandLine.Parse( notAcceptableValue.ToString() );
            } );
      }

      [TestMethod]
      public void RangeValueArgument()
      {
         var withInRange = new Int32[] { 11, 0, -3, 47 };
         var outOfRange = new Int32[] { -4, 48 };

         var commandLine = new CommandLine<RangeValueArgument>();

         foreach ( var value in withInRange )
         {
            var arguments = commandLine.Parse( value.ToString() );
            TestHelper.Expected<Int32>( value, () =>
            {
               return arguments.Int32Value;
            } );
         }

         foreach ( var value in outOfRange )
         {
            TestHelper.ExpectedException( typeof( CommandLineException ), () =>
            {
               var arguments = commandLine.Parse( value.ToString() );
            } );
         }
      }

      [TestMethod]
      public void StringValueArgument()
      {
         var stringValue = "foobar";
         var commandLine = new CommandLine<StringValueArgument>();
         var arguments = commandLine.Parse( stringValue );

         TestHelper.Expected<string>( stringValue, () =>
            {
               return arguments.StringValue;
            } );
      }

      [TestMethod]
      public void AcceptableStringValueArgument()
      {
         var acceptableValue1 = "foo";
         var acceptableValue2 = "bar";
         var unacceptableValue = "far";
         var commandLine = new CommandLine<AcceptableStringValueArgument>();

         var arguments = commandLine.Parse( acceptableValue1 );
         TestHelper.Expected<string>( acceptableValue1, () =>
         {
            return arguments.StringValue;
         } );

         arguments = commandLine.Parse( acceptableValue2 );
         TestHelper.Expected<string>( acceptableValue2, () =>
         {
            return arguments.StringValue;
         } );

         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
            {
               arguments = commandLine.Parse( unacceptableValue );
            } );
      }

      [TestMethod]
      public void MultipleValueArguments()
      {
         var acceptableValues1 = new string[] { "foo", "-a", "hello", "0", "1", "-1", "5" };

         var commandLine = new CommandLine<MultipleValueArguments>();

         var arguments = commandLine.Parse( acceptableValues1 );
         TestHelper.Expected<string>( acceptableValues1[0], () => { return arguments.StringValue1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<string>( acceptableValues1[2], () => { return arguments.StringValue2; } );
         TestHelper.Expected<int>( Int32.Parse( acceptableValues1[3] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<int>( Int32.Parse( acceptableValues1[4] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<int>( Int32.Parse( acceptableValues1[5] ), () => { return arguments.Int32Value3; } );
         TestHelper.Expected<int>( Int32.Parse( acceptableValues1[6] ), () => { return arguments.Int32Value4; } );
      }
#endif

      [TestMethod]
      public void MultipleOrdinalValueSwitchArguments()
      {
         var args1 = new string[] { "23", "foo" };
         var args2 = new string[] { "23", "-red", "-blue", "67", "foo" };
         var args3 = new string[] { "23", "67", "-red", "-blue", "foo" };
         var args4 = new string[] { "23", "-red", "67", "-blue", "foo" };
         var args5 = new string[] { "23", "67", "-blue", "foo" };
         var args6 = new string[] { "23", "-red", "67", "foo" };
         var args7 = new string[] { "23", "-red", "-blue", "foo" };
         var args8 = new string[] { "23", "67", "foo" };

         var commandLine = new CommandLine<MultipleOrdinalValueSwitchArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<String>( args[1], () => { return arguments.StringValue1; } );

         args = args2;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[3] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<String>( args[4], () => { return arguments.StringValue1; } );

         args = args3;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[4], () => { return arguments.StringValue1; } );

         args = args4;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[2] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[4], () => { return arguments.StringValue1; } );

         args = args5;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[3], () => { return arguments.StringValue1; } );

         args = args6;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[2] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<String>( args[3], () => { return arguments.StringValue1; } );

         args = args7;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[3], () => { return arguments.StringValue1; } );

         args = args8;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () => { return arguments.Int32Value2; } );
         TestHelper.Expected<String>( args[2], () => { return arguments.StringValue1; } );
      }
   }
}
