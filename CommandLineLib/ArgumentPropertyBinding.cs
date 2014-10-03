using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IArgumentPropertyBinding
   {
      object Value
      {
         get;
         set;
      }

      bool WasSet
      {
         get;
         set;
      }
   }

   public class ArgumentPropertyBinding : IArgumentPropertyBinding
   {
      private object instance;
      private PropertyInfo property;

      public ArgumentPropertyBinding( object instance, PropertyInfo property )
      {
         this.instance = instance;
         this.property = property;
      }

      public virtual object Value
      {
         get
         {
            return this.property.GetValue( this.instance );
         }
         set
         {
            this.property.SetValue( this.instance, value );
            this.WasSet = true;
         }
      }

      public bool WasSet
      {
         get;
         set;
      }
   }

   public class ValueArgumentPropertyBinding : ArgumentPropertyBinding
   {
      private IConvertibleArgument converter;
      private IAcceptableArgument acceptableTester;

      public ValueArgumentPropertyBinding( object instance, PropertyInfo property, IConvertibleArgument converter, IAcceptableArgument acceptableTester )
         : base( instance, property )
      {
         this.converter = converter;
         this.acceptableTester = acceptableTester;
      }

      public override object Value
      {
         set
         {
            var convertedValue = this.converter.Convert( value );

            if ( !this.acceptableTester.IsAcceptable( convertedValue ) )
            {
               throw new UnacceptableArgumentException( String.Format( "Unacceptable argument value \"{0}\" found.", value ), value );
            }

            base.Value = convertedValue;
         }
      }
   }

   public class RangeValueArgumentPropertyBinding : ValueArgumentPropertyBinding
   {
      private IRangeableArgument rangeTester;

      public RangeValueArgumentPropertyBinding( object instance, PropertyInfo property, IConvertibleArgument converter, IAcceptableArgument acceptableTester, IRangeableArgument rangeTester )
         : base( instance, property, converter, acceptableTester )
      {
         this.rangeTester = rangeTester;
      }

      public override object Value
      {
         set
         {
            base.Value = value;

            if ( !this.rangeTester.IsInRange( base.Value ) )
            {
               throw new ArgumentOutOfRangeException( "Value" );
            }
         }
      }
   }
}
