using System;
using System.Collections.Generic;
using System.Reflection;

namespace CommandLineLib
{
   public class AttibutePropertyBinder
   {
      public List<AttibutePropertyPair> Pairs
      {
         get;
         private set;
      }

      public AttibutePropertyBinder()
      {
         this.Pairs = new List<AttibutePropertyPair>();
      }

      public void Add( IBaseAttribute attribute, PropertyInfo property )
      {
         this.Pairs.Add( new AttibutePropertyPair( attribute, property ) );
      }

      public IList<IBaseArgument> Bind( object instance )
      {
         List<IBaseArgument> boundArguments = new List<IBaseArgument>();

         foreach ( var pair in this.Pairs )
         {
            boundArguments.Add( pair.Attribute.CreateArgument( instance, pair.Property ) );
         }

         return boundArguments;
      }
   }
}
