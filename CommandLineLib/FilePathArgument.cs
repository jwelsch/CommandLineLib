using System;
using System.IO;

namespace CommandLineLib
{
   public class FilePathArgument : BaseArgument
   {
      public FilePathArgument( PropertyAccessor property, IAttributeData attributeData, bool mustExist )
         : base( property, attributeData )
      {
         this.MustExist = mustExist;
      }

      public bool MustExist
      {
         get;
         private set;
      }

      public override bool MatchCommandLineArgument( string value )
      {
         return true;
      }

      public override void SetFromCommandLineArgument( string value )
      {
         if ( this.MustExist )
         {
            if ( !File.Exists( value ) )
            {
               throw new FileNotFoundException( String.Format( "The file at \"{0}\" does not exist.", value ), value );
            }
         }

         this.Property.SetValue( value );
      }

      public bool Exists()
      {
         return File.Exists( (string) this.Property.GetValue() );
      }
   }
}
