using System;
using System.IO;

namespace CommandLineLib
{
   public class FilePath : ValueBaseAttribute
   {
      public FilePath( int ordinal )
         : base( ordinal, typeof( String ) )
      {
      }

      public bool MustExist
      {
         get;
         set;
      }

      public override object FromString( string argument )
      {
         return argument;
      }

      protected override bool Validate( object convertedValue )
      {
         if ( this.MustExist )
         {
            if ( !File.Exists( (string) convertedValue ) )
            {
               throw new FileNotFoundException( String.Format( "The file was not found at path \"{0}\" for the argument \"{1}\".", convertedValue, this.ShortName ), (string) convertedValue );
            }
         }

         return true;
      }
   }
}
