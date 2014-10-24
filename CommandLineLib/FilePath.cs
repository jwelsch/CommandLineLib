using System;
using System.IO;

namespace CommandLineLib
{
   public class FilePath : PathBaseAttribute
   {
      public FilePath( int ordinal )
         : base( ordinal )
      {
      }

      protected override IOException CheckIfExists( string path )
      {
         if ( File.Exists( path ) )
         {
            return null;
         }

         return new FileNotFoundException( String.Format( "The file does not exist at path \"{0}\" for the argument \"{1}\".", path, this.ShortName ), path );
      }
   }
}
