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

         arguments = commandLine.Parse( new string[] { "-bar" } );
         TestHelper.Expected<bool>( false, () =>
         {
            return arguments.Foo;
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
      public void DuplicateSwitch()
      {
         TestHelper.ExpectedException( typeof( CommandLineException ), () =>
         {
            var commandLine = new CommandLine<DoubleSwitchArguments>();
            var arguments = commandLine.Parse( new string[] { "-foo", "-foo" } );
         } );
      }
   }
}
