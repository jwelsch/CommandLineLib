﻿using System;
using System.IO;
using System.Reflection;
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
         TestHelper.ExpectedException<NoCommandLineAttributesFoundException>( () =>
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

         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
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

         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo", "-bar1" } );
         } );

         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo1", "-bar" } );
         } );

         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
         {
            arguments = commandLine.Parse( new string[] { "-foo1", "-bar1" } );
         } );
      }

      [TestMethod]
      public void DuplicateSwitch()
      {
         TestHelper.ExpectedException<DuplicateArgumentException>( () =>
         {
            var commandLine = new CommandLine<OptionalSwitchArguments>();
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

         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
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

         TestHelper.ExpectedException<ArgumentOutOfOrderException>( () =>
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

         TestHelper.ExpectedException<GroupNotAllowedException>( () =>
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

         TestHelper.ExpectedException<ValueNotAcceptableException>( () =>
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
            TestHelper.ExpectedException<ValueOutOfRangeException>( () =>
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

         TestHelper.ExpectedException<ValueNotAcceptableException>( () =>
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
         TestHelper.ExpectedException<DuplicateOrdinalException>( () =>
            {
               var commandLine = new CommandLine<SameOrdinalValueArguments>();
            } );
      }

      [TestMethod]
      public void SameOrdinalValueSwitchArguments()
      {
         TestHelper.ExpectedException<DuplicateOrdinalException>( () =>
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
         TestHelper.ExpectedException<AmbiguousArgumentException>( () =>
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
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalSwitchTypeArguments>();
         } );
      }

      [TestMethod]
      public void IllegalValueTypeArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalStringTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalSByteValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalInt16ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalInt32ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalInt64ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalByteValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalUInt16ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalUInt32ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalUInt64ValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalSingleValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalDoubleValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalDecimalValueTypeArguments>();
         } );

         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<IllegalDateTimeValueTypeArguments>();
         } );
      }

      [TestMethod]
      public void DescriptionArguments()
      {
         var commandLine = new CommandLine<DescriptionArguments>();
         var args = new string[] { "1", "-foo" };
         var arguments = commandLine.Parse( args );
      }

      [TestMethod]
      public void ShortNameArguments()
      {
         var commandLine = new CommandLine<ShortNameArguments>();
         var args = new string[] { "1", "-foo" };
         var arguments = commandLine.Parse( args );
      }

      [TestMethod]
      public void ValueSwitchGroupArguments()
      {
         var commandLine = new CommandLine<ValueSwitchGroupArguments>();
         var args1 = new string[] { "Hello", "123", "-foo" };
         var args2 = new string[] { "Hello", "123", "-bar" };
         var args3 = new string[] { "Hello", "123", "-foo", "-bar" };

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[0], () =>
            {
               return arguments.String_1;
            } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
         {
            return arguments.Int32_1;
         } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Bar;
         } );

         args = args2;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[0], () =>
         {
            return arguments.String_1;
         } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
         {
            return arguments.Int32_1;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Foo;
         } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Bar;
         } );

         TestHelper.ExpectedException<GroupNotAllowedException>( () =>
            {
               commandLine.Parse( args3 );
            } );
      }

      [TestMethod]
      public void CompoundArguments()
      {
         var args1 = new string[] { "-foo", "1", "-bar", "Red" };
         var args2 = new string[] { "-bar", "Red", "-foo", "1" };
         var args3 = new string[] { "-foo", "Red", "-bar", "White" };
         var args4 = new string[] { "-foo", "Red", "-bar", "Black" };

         var commandLine = new CommandLine<CompoundArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args1 );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
            {
               return arguments.Foo;
            } );
         TestHelper.Expected<String>( args[3], () =>
         {
            return arguments.Bar;
         } );

         args = args2;
         TestHelper.ExpectedException<ArgumentOutOfOrderException>( () =>
            {
               commandLine.Parse( args );
            } );

         args = args3;
         TestHelper.ExpectedException<ArgumentFormatException>( () =>
         {
            commandLine.Parse( args );
         } );

         args = args4;
         TestHelper.ExpectedException<ArgumentFormatException>( () =>
         {
            commandLine.Parse( args );
         } );
      }

      [TestMethod]
      public void InvalidInt32CompoundArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
            {
               var commandLine = new CommandLine<InvalidInt32CompoundArguments>();
            } );
      }

      [TestMethod]
      public void SamePrefixLabelSwitchArguments()
      {
         TestHelper.ExpectedException<SharedIdentifierException>( () =>
            {
               var commandLine = new CommandLine<SamePrefixLabelSwitchArguments>();
            } );
      }

      [TestMethod]
      public void SamePrefixLabelCompoundArguments()
      {
         TestHelper.ExpectedException<SharedIdentifierException>( () =>
         {
            var commandLine = new CommandLine<SamePrefixLabelCompoundArguments>();
         } );
      }

      [TestMethod]
      public void SamePrefixLabelSwitchCompoundArguments()
      {
         TestHelper.ExpectedException<SharedIdentifierException>( () =>
         {
            var commandLine = new CommandLine<SamePrefixLabelSwitchCompoundArguments>();
         } );
      }

      [TestMethod]
      public void EnumValueArguments()
      {
         var commandLine = new CommandLine<EnumValueArguments>();
         var arguments = commandLine.Parse( Shapes.Circle.ToString() );

         TestHelper.Expected<Shapes>( Shapes.Circle, () =>
            {
               return arguments.Enum1;
            } );
      }

      [TestMethod]
      public void InvalidEnumValueArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
            {
               var commandLine = new CommandLine<InvalidEnumValueArguments>();
            } );
      }

      [TestMethod]
      public void EnumCompoundArguments()
      {
         var args = new string[] { "-foo", Shapes.Circle.ToString() };
         var commandLine = new CommandLine<EnumCompoundArguments>();
         var arguments = commandLine.Parse( args );

         TestHelper.Expected<Shapes>( Shapes.Circle, () =>
         {
            return arguments.Enum1;
         } );
      }

      [TestMethod]
      public void InvalidEnumCompoundArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<InvalidEnumCompoundArguments>();
         } );
      }

      [TestMethod]
      public void FilePathValueArguments()
      {
         var args1 = new string[] { @"C:\Foo\Bar.txt", @".\CommandLineLib.dll" };
         var args2 = new string[] { @"C:\Foo\Bar.txt", @".\CommandLineLib.foobar" };

         var commandLine = new CommandLine<FilePathValueArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[0], () =>
            {
               return arguments.FilePath1;
            } );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.FilePath2;
         } );

         args = args2;
         TestHelper.ExpectedException<System.IO.FileNotFoundException>( () =>
            {
               commandLine.Parse( args );
            } );
      }

      [TestMethod]
      public void InvalidFilePathValueArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
            {
               var commandLine = new CommandLine<InvalidFilePathValueArguments>();
            } );
      }

      [TestMethod]
      public void FilePathCompoundArguments()
      {
         var args1 = new string[] { "-foo", @"C:\Foo\Bar.txt", "-bar", @".\CommandLineLib.dll" };
         var args2 = new string[] { "-foo", @"C:\Foo\Bar.txt", "-bar", @".\CommandLineLib.foobar" };

         var commandLine = new CommandLine<FilePathCompoundArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.FilePath1;
         } );
         TestHelper.Expected<string>( args[3], () =>
         {
            return arguments.FilePath2;
         } );

         args = args2;
         TestHelper.ExpectedException<System.IO.FileNotFoundException>( () =>
         {
            commandLine.Parse( args );
         } );
      }

      [TestMethod]
      public void InvalidFilePathCompoundArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
            {
               var commandLine = new CommandLine<InvalidFilePathCompoundArguments>();
            } );
      }

      [TestMethod]
      public void CommandLineHelpText()
      {
         var commandLine = new CommandLine<CommandLineHelpTextArguments>();
         var help = commandLine.Help();
         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> {-halb -peeb <Compound_A1> <oof>}|{-fish -goat <Compound_B1> <dog>}

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
-halb: Here we have a switch halb.
-peeb: Here we have a compound argument peeb.
oof: This is an Int32 value that specifies oof.
-fish: Here we have a switch fish.
-goat: Here we have a compound argument goat.
dog: This is an Int32 value that specifies dog.
";

         TestHelper.Expected<string>( correct, () =>
            {
               return help;
            } );
      }

      [TestMethod]
      public void CommandLineHelpTextOptionalArguments()
      {
         var commandLine = new CommandLine<CommandLineHelpTextOptionalArguments>();
         var help = commandLine.Help();

         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> [<bar>]

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
bar: This is an optional Int32 value that specifies bar.
";

         TestHelper.Expected<string>( correct, () =>
         {
            return help;
         } );
      }

      [TestMethod]
      public void CommandLineHelpTextProvideAssemblyName()
      {
         var commandLine = new CommandLine<CommandLineHelpTextArguments>();
         var help = commandLine.Help( Path.GetFileName( Assembly.GetExecutingAssembly().Location ) );
         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> {-halb -peeb <Compound_A1> <oof>}|{-fish -goat <Compound_B1> <dog>}

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
-halb: Here we have a switch halb.
-peeb: Here we have a compound argument peeb.
oof: This is an Int32 value that specifies oof.
-fish: Here we have a switch fish.
-goat: Here we have a compound argument goat.
dog: This is an Int32 value that specifies dog.
";

         TestHelper.Expected<string>( correct, () =>
         {
            return help;
         } );
      }

      [TestMethod]
      public void CommandLineHelpTextOptionalArgumentsProvideAssemblyName()
      {
         var commandLine = new CommandLine<CommandLineHelpTextOptionalArguments>();
         var help = commandLine.Help( Path.GetFileName( Assembly.GetExecutingAssembly().Location ) );

         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> [<bar>]

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
bar: This is an optional Int32 value that specifies bar.
";

         TestHelper.Expected<string>( correct, () =>
         {
            return help;
         } );
      }

      [TestMethod]
      public void CommandLineHelpTextProvideAssemblyNameVersion()
      {
         var commandLine = new CommandLine<CommandLineHelpTextArguments>();
         var assembly = Assembly.GetExecutingAssembly();
         var help = commandLine.Help( Path.GetFileName( assembly.Location ), assembly.GetName().Version );
         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> {-halb -peeb <Compound_A1> <oof>}|{-fish -goat <Compound_B1> <dog>}

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
-halb: Here we have a switch halb.
-peeb: Here we have a compound argument peeb.
oof: This is an Int32 value that specifies oof.
-fish: Here we have a switch fish.
-goat: Here we have a compound argument goat.
dog: This is an Int32 value that specifies dog.
";

         TestHelper.Expected<string>( correct, () =>
         {
            return help;
         } );
      }

      [TestMethod]
      public void CommandLineHelpTextOptionalArgumentsProvideAssemblyNameVersion()
      {
         var commandLine = new CommandLine<CommandLineHelpTextOptionalArguments>();
         var assembly = Assembly.GetExecutingAssembly();
         var help = commandLine.Help( Path.GetFileName( assembly.Location ), assembly.GetName().Version );

         var correct = @"CommandLineTest.exe v1.0.0.0

Command line usage:
   CommandLineTest.exe -blah -beep <Compound_1> <foo> [<bar>]

-blah: Here we have a switch.
-beep: Here we have a compound argument.
foo: This is an Int32 value that specifies foo.
bar: This is an optional Int32 value that specifies bar.
";

         TestHelper.Expected<string>( correct, () =>
         {
            return help;
         } );
      }

      [TestMethod]
      public void InvalidCharacterSwitchArguments()
      {
         TestHelper.ExpectedException<BadIdentifierException>( () =>
            {
               var commandLine = new CommandLine<InvalidCharacterSwitchArguments1>();
            } );

         TestHelper.ExpectedException<BadIdentifierException>( () =>
         {
            var commandLine = new CommandLine<InvalidCharacterSwitchArguments2>();
         } );

         TestHelper.ExpectedException<BadIdentifierException>( () =>
         {
            var commandLine = new CommandLine<InvalidCharacterSwitchArguments3>();
         } );

         TestHelper.ExpectedException<BadIdentifierException>( () =>
         {
            var commandLine = new CommandLine<InvalidCharacterSwitchArguments4>();
         } );
      }

      [TestMethod]
      public void SwitchAliasArguments()
      {
         var args1 = new string[] { "-foo" };
         var args2 = new string[] { "-f" };
         var args3 = new string[] { "--f" };

         var commandLine = new CommandLine<SwitchAliasArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<bool>( true, () =>
            {
               return arguments.Switch1;
            } );

         args = args2;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Switch1;
         } );

         args = args3;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Switch1;
         } );
      }

      [TestMethod]
      public void CompoundAliasArguments()
      {
         var args1 = new string[] { "-foo", "bar" };
         var args2 = new string[] { "\\f", "bar" };
         var args3 = new string[] { "/f", "bar" };

         var commandLine = new CommandLine<CompoundAliasArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.Compound1;
         } );

         args = args2;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.Compound1;
         } );

         args = args3;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.Compound1;
         } );
      }

      [TestMethod]
      public void AutomaticShortNameArguments()
      {
         var args = new string[] { "1", "2", "-foo", "-bar", "-oof", "3", "-rab", "4" };
         var commandLine = new CommandLine<AutomaticShortNameArguments>();
         var arguments = commandLine.Parse( args );
      }

      [TestMethod]
      public void OnlySupplyFirstPartOfCompoundArgument()
      {
         var args = new string[] { "-foo" };
         var commandLine = new CommandLine<EnumCompoundArguments>();

         TestHelper.ExpectedException<CompoundArgumentValueMissingException>( () =>
            {
               commandLine.Parse( args );
            } );
      }

      [TestMethod]
      public void SameAliasArguments()
      {
         TestHelper.ExpectedException<DuplicateIdentifierException>( () =>
            {
               var commandLine = new CommandLine<SameAliasArguments>();
            } );
      }

      [TestMethod]
      public void SameIdentifierAndAliasArguments()
      {
         TestHelper.ExpectedException<DuplicateIdentifierException>( () =>
         {
            var commandLine = new CommandLine<SameIdentifierAndAliasArguments>();
         } );
      }

      [TestMethod]
      public void TwoSameAliasArguments()
      {
         TestHelper.ExpectedException<SharedIdentifierException>( () =>
         {
            var commandLine = new CommandLine<TwoSameAliasArguments>();
         } );
      }

      [TestMethod]
      public void TwoSameIdentifierAndAliasArguments()
      {
         TestHelper.ExpectedException<SharedIdentifierException>( () =>
         {
            var commandLine = new CommandLine<TwoSameIdentifierAndAliasArguments>();
         } );
      }

      [TestMethod]
      public void DirectoryPathValueArguments()
      {
         var args1 = new string[] { @"C:\Foo\Bar", @".\" };
         var args2 = new string[] { @"C:\Foo\Bar", @".\Foobar" };

         var commandLine = new CommandLine<DirectoryPathValueArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[0], () =>
         {
            return arguments.DirectoryPath1;
         } );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.DirectoryPath2;
         } );

         args = args2;
         TestHelper.ExpectedException<System.IO.DirectoryNotFoundException>( () =>
         {
            commandLine.Parse( args );
         } );
      }

      [TestMethod]
      public void InvalidDirectoryPathValueArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<InvalidDirectoryPathValueArguments>();
         } );
      }

      [TestMethod]
      public void DirectoryPathCompoundArguments()
      {
         var args1 = new string[] { "-foo", @"C:\Foo\Bar", "-bar", @".\" };
         var args2 = new string[] { "-foo", @"C:\Foo\Bar", "-bar", @".\Foobar" };

         var commandLine = new CommandLine<DirectoryPathCompoundArguments>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<string>( args[1], () =>
         {
            return arguments.DirectoryPath1;
         } );
         TestHelper.Expected<string>( args[3], () =>
         {
            return arguments.DirectoryPath2;
         } );

         args = args2;
         TestHelper.ExpectedException<System.IO.DirectoryNotFoundException>( () =>
         {
            commandLine.Parse( args );
         } );
      }

      [TestMethod]
      public void InvalidDirectoryPathCompoundArguments()
      {
         TestHelper.ExpectedException<ArgumentTypeMismatchException>( () =>
         {
            var commandLine = new CommandLine<InvalidDirectoryPathCompoundArguments>();
         } );
      }

      [TestMethod]
      public void GroupOptionalPrecedence()
      {
         var args1A = new string[] { "-group1", "1" };
         var args1B = new string[] { "-group1", "1", "-switch1" };
         var args2A = new string[] { "-group2", "2" };
         var args2B = new string[] { "-group2", "2", "-switch2" };

         var commandLine = new CommandLine<GroupOptionalPrecedence>();

         var args = args1A;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
            {
               return arguments.Group1;
            } );
         TestHelper.Expected<bool>( false, () =>
            {
               return arguments.Switch1;
            } );
         TestHelper.Expected<Int32>( 0, () =>
         {
            return arguments.Group2;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Switch2;
         } );

         args = args1B;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
         {
            return arguments.Group1;
         } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Switch1;
         } );
         TestHelper.Expected<Int32>( 0, () =>
         {
            return arguments.Group2;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Switch2;
         } );

         args = args2A;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( 0, () =>
         {
            return arguments.Group1;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Switch1;
         } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
         {
            return arguments.Group2;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Switch2;
         } );

         args = args2B;
         arguments = commandLine.Parse( args );
         TestHelper.Expected<Int32>( 0, () =>
         {
            return arguments.Group1;
         } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Switch1;
         } );
         TestHelper.Expected<Int32>( Int32.Parse( args[1] ), () =>
         {
            return arguments.Group2;
         } );
         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Switch2;
         } );
      }

      [TestMethod]
      public void EnumCaseSensitive()
      {
         var args1 = new string[] { "Circle", "-enumCompound", "Square" };
         var args2 = new string[] { "circle", "-enumCompound", "Square" };
         var args3 = new string[] { "Circle", "-enumCompound", "square" };

         var commandLine = new CommandLine<EnumCaseSensitive>();

         var args = args1;
         var arguments = commandLine.Parse( args );
         TestHelper.Expected<Shapes>( Shapes.Circle, () =>
            {
               return arguments.CaseSensitiveEnumValue;
            } );
         TestHelper.Expected<Shapes>( Shapes.Square, () =>
         {
            return arguments.CaseSensitiveEnumCompound;
         } );

         args = args2;
         TestHelper.ExpectedException<ArgumentNotFoundException>( () =>
            {
               arguments = commandLine.Parse( args );
            } );

         args = args3;
         TestHelper.ExpectedException<ArgumentFormatException>( () =>
         {
            arguments = commandLine.Parse( args );
         } );
      }

      [TestMethod]
      public void NotAProperty()
      {
         TestHelper.ExpectedException<InvalidMemberException>( () =>
            {
               var commandLine = new CommandLine<NotAPropertyArgument>();
            } );
      }
//#endif

      [TestMethod]
      public void SwitchReverse()
      {
         var commandLine = new CommandLine<SwitchReverse>();
         var arguments = commandLine.Parse( "-foo" );

         TestHelper.Expected<bool>( false, () =>
            {
               return arguments.Foo;
            } );

         arguments = commandLine.Parse( "" );

         TestHelper.Expected<bool>( true, () =>
         {
            return arguments.Foo;
         } );
      }
   }
}
