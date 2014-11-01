using System;
using System.Reflection;

namespace CommandLineLib
{
   public class EnumValue : ValueBaseAttribute
   {
      public bool ValueCaseSensitive
      {
         get;
         set;
      }

      public EnumValue( int ordinal )
         : base( ordinal, typeof( Enum ) )
      {
      }

      public override void SetProperty( PropertyInfo property )
      {
         if ( !property.PropertyType.IsEnum )
         {
            throw new CommandLineDeclarationException( String.Format( "The argument \"{0}\" does not decorate a property or field that is an enum.", this.ShortName ) );
         }

         this.ValueType = property.PropertyType;
         base.SetProperty( property );
      }

      public override object FromString( string argument )
      {
         var enumType = typeof( Enum );

         if ( this.ParseMethodInfo == null )
         {
            var methods = enumType.GetMethods( BindingFlags.Public | BindingFlags.Static );

            foreach ( var method in methods )
            {
               if ( method.Name == "TryParse" )
               {
                  var parameters = method.GetParameters();
                  var match = 0;

                  foreach ( var parameter in parameters )
                  {
                     if ( ( parameter.ParameterType == typeof( String ) ) && ( parameter.Position == 0 ) )
                     {
                        match++;
                     }
                     else if ( ( parameter.ParameterType == typeof( Boolean ) ) && ( parameter.Position == 1 ) )
                     {
                        match++;
                     }
                     else if ( parameter.IsOut && ( parameter.Position == 2 ) )
                     {
                        match++;
                     }
                  }

                  if ( match == 3 )
                  {
                     this.ParseMethodInfo = method.MakeGenericMethod( this.ValueType );
                     break;
                  }
               }
            }

            if ( this.ParseMethodInfo == null )
            {
               return null;
            }
         }

         var converted = Activator.CreateInstance( this.ValueType );
         var args = new object[] { argument, !this.ValueCaseSensitive, converted };
         var result = this.ParseMethodInfo.Invoke( null, args );

         if ( !(bool) result )
         {
            return null;
         }

         return args[2];
      }
   }
}
