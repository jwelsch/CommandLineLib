using System;
using System.IO;

namespace CommandLineLib
{
   public abstract class PathBaseAttribute : ValueBaseAttribute
   {
      public PathBaseAttribute( int ordinal )
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
            var exception = this.CheckIfExists( (string) convertedValue );
            if ( exception != null )
            {
               throw exception;
            }
         }

         return true;
      }

      protected abstract IOException CheckIfExists( string path );
   }
}
