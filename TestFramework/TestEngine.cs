using System;
using System.Collections.Generic;

namespace TestFramework
{
   public class TestEngine
   {
      public TestRunResult RunTests( object testObject, IProgressWriter writer )
      {
         var extractor = new TestExtractor();
         var testCollection = extractor.ExtractTestMethods( testObject );

         return this.RunTests( testCollection, writer );
      }

      public TestRunResult RunTests( TestCollection testCollection, IProgressWriter writer )
      {
         writer.WriteLine( "Found {0} test{1} to run.", testCollection.Count, testCollection.Count == 1 ? string.Empty : "s" );

         var testResults = new List<TestResult>();

         foreach ( var test in testCollection )
         {
            var testMethod = (Action) Delegate.CreateDelegate( typeof( Action ), test.Instance, test.MethodInfo.Name );

            try
            {
               testMethod();
            }
            catch ( Exception ex )
            {
               testResults.Add( TestResult.Failed( test.MethodInfo.Name, ex ) );
               writer.WriteLine( "{0}/{1} failed {2}: {3}", testResults.Count, testCollection.Count, test.MethodInfo.Name, ex.Message );
               System.Diagnostics.Trace.WriteLine( ex );
               continue;
            }

            testResults.Add( TestResult.Suceeded( test.MethodInfo.Name ) );
            writer.WriteLine( "{0}/{1} successful {2}.", testResults.Count, testCollection.Count, test.MethodInfo.Name );
         }

         return new TestRunResult( testResults.ToArray() );
      }
   }

   #region Test Attributes

   public class TestMethod : System.Attribute
   {
   }

   #endregion
}