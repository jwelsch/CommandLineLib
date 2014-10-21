using System;
using System.Reflection;

namespace CommandLineLib
{
   public abstract class ValueBaseAttribute : BaseAttribute, IValueAttribute
   {
      protected MethodInfo ParseMethodInfo
      {
         get;
         set;
      }

      protected Type ValueType
      {
         get;
         set;
      }

      public ValueBaseAttribute( int ordinal, Type valueType )
      {
         this.Ordinal = ordinal;
         this.ValueType = valueType;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         protected set { base.Ordinal = value; }
      }

      public override string UsageText
      {
         get { return CommandLineUsage.GenerateUsageText( this.ShortName, this.Optional, true ); }
      }

      public override void SetProperty( PropertyInfo property )
      {
         if ( this.ValueType != property.PropertyType )
         {
            throw new ArgumentTypeMismatchException( String.Format( "The argument \"{0}\" expects type \"{1}\", but is decorating a property or field with type \"{2}\".", this.ShortName, this.ValueType.Name, property.PropertyType.Name ) );
         }

         base.SetProperty( property );
      }

      public override bool MatchArgument( string argument )
      {
         return ( null != this.FromString( argument ) );
      }

      public override bool SetArgument( object instance, string argument )
      {
         var converted = this.FromString( argument );

         if ( converted == null )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" could not be converted into type \"{1}\" for argument \"{2}\".", argument, this.ValueType.Name, this.ShortName ) );
         }

         if ( !this.Validate( converted ) )
         {
            return false;
         }

         this.Property.SetValue( instance, converted );

         return true;
      }

      public virtual object FromString( string argument )
      {
         if ( this.ParseMethodInfo == null )
         {
            this.ParseMethodInfo = this.ValueType.GetMethod( "TryParse", new Type[] { typeof( System.String ), this.ValueType.MakeByRefType() } );

            if ( this.ParseMethodInfo == null )
            {
               return null;
            }
         }

         var converted = Activator.CreateInstance( this.ValueType );
         var args = new object[] { argument, converted };
         var result = this.ParseMethodInfo.Invoke( null, args );

         if ( !(bool) result )
         {
            return null;
         }

         return args[1];
      }

      protected virtual bool Validate( object convertedValue )
      {
         return true;
      }
   }
}
