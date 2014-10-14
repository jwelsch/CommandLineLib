using System;
using System.Reflection;

namespace CommandLineLib
{
   public class FilePath : Value
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

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new FilePathArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.MustExist );
      }
   }
}
