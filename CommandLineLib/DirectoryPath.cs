using System;
using System.IO;

namespace CommandLineLib
{
   public class DirectoryPath : PathBaseAttribute
   {
      public DirectoryPath( int ordinal )
         : base( ordinal )
      {
      }

      protected override IOException CheckIfExists( string path )
      {
         if ( Directory.Exists( path ) )
         {
            return null;
         }

         return new DirectoryNotFoundException( String.Format( "The directory does not exist at path \"{0}\" for the argument \"{1}\".", path, this.ShortName ) );
      }
   }
}
