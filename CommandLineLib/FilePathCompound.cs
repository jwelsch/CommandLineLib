using System;
using System.Reflection;

namespace CommandLineLib
{
   public class FilePathCompound : CompoundAttribute
   {
      public bool MustExist
      {
         get;
         set;
      }

      public FilePathCompound( string prefix, string label )
         : base( prefix, label, typeof( string ) )
      {
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new FilePathCompoundArgument( new PropertyAccessor( instance, propertyInfo ), this, this.CaseSensitive, this.Prefix, this.Label, this.MustExist );
      }
   }
}
