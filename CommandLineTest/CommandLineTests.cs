﻿using System;
using CommandLineLib;
using TestFramework;

namespace CommandLineTest
{
   public class CommandLineTests
   {
      //#if false
      [TestMethod]
      public void NoCommandLineAttributes()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
            {
               var commandLine = new CommandLine<EmptyArguments>();
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

      [TestMethod]
      public void SameOrdinalValueArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
            {
               var commandLine = new CommandLine<SameOrdinalValueArguments>();
            } );
      }

      [TestMethod]
      public void SameOrdinalValueSwitchArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<SameOrdinalValueSwitchArguments>();
         } );
      }

      [TestMethod]
      public void MultipleOrdinalValueSwitchArguments()
      {
         var commandLine = new CommandLine<MultipleOrdinalValueSwitchArguments>();

         var args = new string[] { "23", "foo" };
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<String>( args[1], () => { return arguments.StringValue1; } );

         args = new string[] { "23", "-red", "-blue", "foo", "67" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[3], () => { return arguments.StringValue1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[4] ), () => { return arguments.Int32Value2; } );

         args = new string[] { "23", "-red", "-blue", "foo" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[3], () => { return arguments.StringValue1; } );

         args = new string[] { "23", "-blue", "foo", "67" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[2], () => { return arguments.StringValue1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[3] ), () => { return arguments.Int32Value2; } );

         args = new string[] { "23", "-red", "foo", "67" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<String>( args[2], () => { return arguments.StringValue1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[3] ), () => { return arguments.Int32Value2; } );

         args = new string[] { "23", "-blue", "foo" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch2; } );
         TestHelper.Expected<String>( args[2], () => { return arguments.StringValue1; } );

         args = new string[] { "23", "-red", "foo" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<bool>( true, () => { return arguments.Switch1; } );
         TestHelper.Expected<String>( args[2], () => { return arguments.StringValue1; } );

         args = new string[] { "23", "foo", "67" };
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[0] ), () => { return arguments.Int32Value1; } );
         TestHelper.Expected<String>( args[1], () => { return arguments.StringValue1; } );
         TestHelper.Expected<Int32>( Int32.Parse( args[2] ), () => { return arguments.Int32Value2; } );
      }

      [TestMethod]
      public void IllegalOptionalValueArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalOptionalValueArguments>();
         } );
      }

      [TestMethod]
      public void LegalOptionalValueArguments()
      {
         var commandLine = new CommandLine<LegalOptionalValueArguments>();

         var args = new string[] { };
      }

      [TestMethod]
      public void IllegalSwitchTypeArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalSwitchTypeArguments>();
         } );
      }

      [TestMethod]
      public void IllegalValueTypeArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalStringTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalSByteValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalInt16ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalInt32ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalInt64ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalByteValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalUInt16ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalUInt32ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalUInt64ValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalSingleValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalDoubleValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalDecimalValueTypeArguments>();
         } );

         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalDateTimeValueTypeArguments>();
         } );
      }

      [TestMethod]
      public void IllegalCommandLineAttibuteArguments()
      {
         TestHelper.ExpectedException( typeof( CommandLineDeclarationException ), () =>
         {
            var commandLine = new CommandLine<IllegalCommandLineAttibuteArguments>();
         } );
      }
      //#endif
   }
}
