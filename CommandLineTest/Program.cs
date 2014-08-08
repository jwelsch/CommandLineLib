using System;
using System.Collections.Generic;

namespace CommandLineTest
{
   class Program
   {
      static void Main( string[] args )
      {
         try
         {
            var tests = new CommandLineTests();
            var consoleWriter = new ConsoleWriter();
            var testEngine = new TestFramework.TestEngine();

            testEngine.RunTests( tests, consoleWriter );
         }
         catch ( Exception ex )
         {
            System.Diagnostics.Trace.WriteLine( ex );
            Console.WriteLine( ex );
         }
      }

      #region ConsoleWriter

      public class ConsoleWriter : TestFramework.IProgressWriter
      {
         #region IProgressWriter Members

         public void Write( string format, params object[] parameters )
         {
            Console.Write( String.Format( format, parameters ) );
         }

         public void WriteLine( string format, params object[] parameters )
         {
            Console.WriteLine( String.Format( format, parameters ) );
         }

         #endregion
      }

      #endregion
   }
}
