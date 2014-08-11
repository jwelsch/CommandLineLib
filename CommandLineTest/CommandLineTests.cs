using System;
using CommandLineLib;
using TestFramework;

namespace CommandLineTest
{
   public class CommandLineTests
   {
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
   }
}
