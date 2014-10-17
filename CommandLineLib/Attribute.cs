using System;
using System.Reflection;

namespace CommandLineLib
{
   [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property )]
   public abstract class BaseAttribute : System.Attribute, IBaseAttribute
   {
      protected PropertyInfo Property
      {
         get;
         private set;
      }

      private int ordinal;
      public int Ordinal
      {
         get { return this.ordinal; }
         set { this.ordinal = ( value < 0 ? 0 : value ); }
      }

      public bool Optional
      {
         get;
         set;
      }

      public int[] Groups
      {
         get;
         set;
      }

      public string Description
      {
         get;
         set;
      }

      public string ShortName
      {
         get;
         set;
      }

      public bool IsCompound
      {
         get;
         protected set;
      }

      public virtual void SetProperty( PropertyInfo property )
      {
         this.Property = property;
      }

      public abstract bool MatchArgument( string argument );

      public virtual bool SetArgument( object instance, string argument )
      {
         this.Property.SetValue( instance, argument );

         return true;
      }
   }

   public class Switch : BaseAttribute, ISwitchAttribute
   {
      public Switch( string prefix, string label )
      {
         this.Prefix = prefix;
         this.Label = label;
      }

      public bool CaseSensitive
      {
         get;
         set;
      }

      public string Prefix
      {
         get;
         private set;
      }

      public string Label
      {
         get;
         private set;
      }

      public string[] Aliases
      {
         get;
         set;
      }

      public override bool MatchArgument( string argument )
      {
         return ( 0 == String.Compare( this.Prefix + this.Label, argument, !this.CaseSensitive ) );
      }

      public override bool SetArgument( object instance, string argument )
      {
         this.Property.SetValue( instance, true );

         return true;
      }
   }

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

      public override void SetProperty( PropertyInfo property )
      {
         if ( this.ValueType != property.PropertyType )
         {
            throw new CommandLineDeclarationException( String.Format( "The argument \"{0}\" expects type \"{1}\", but is decorating a property or field with type \"{2}\".", this.ShortName, this.ValueType.Name, property.PropertyType.Name ) );
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

   public abstract class AcceptableValueBaseAttribute : ValueBaseAttribute, IAcceptableValueAttribute
   {
      public AcceptableValueBaseAttribute( int ordinal, Type valueType )
         : base( ordinal, valueType )
      {
      }

      protected override bool Validate( object convertedValue )
      {
         if ( !this.IsAcceptable( convertedValue ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is not acceptable for this argument.", convertedValue ) );
         }

         return true;
      }

      protected abstract bool IsAcceptable( object value );
   }

   public abstract class RangeValueBaseAttribute : AcceptableValueBaseAttribute, IRangeValueAttribute
   {
      public RangeValueBaseAttribute( int ordinal, Type valueType )
         : base( ordinal, valueType )
      {
      }

      protected override bool Validate( object convertedValue )
      {
         if ( !this.IsInRange( convertedValue ) )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" is out of range for this argument \"{1}\".", convertedValue, this.ShortName ) );
         }

         return base.Validate( convertedValue );
      }

      protected abstract bool IsInRange( object value );
   }

   public class EnumValue : ValueBaseAttribute
   {
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
            this.ParseMethodInfo = enumType.GetMethod( "TryParse", new Type[] { typeof( System.String ), this.ValueType.MakeByRefType() } );

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
   }

   public class EnumCompound : EnumValue, ICompoundAttribute
   {
      private CompoundManager manager;

      public EnumCompound( string prefix, string label )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, prefix, label );
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.manager.CaseSensitive; }
         set { this.manager.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.manager.Prefix; }
      }

      public string Label
      {
         get { return this.manager.Label; }
      }

      public string[] Aliases
      {
         get { return this.manager.Aliases; }
         set { this.manager.Aliases = value; }
      }

      #endregion

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }

   public class StringValue : AcceptableValueBaseAttribute
   {
      public StringValue( int ordinal )
         : base( ordinal, typeof( String ) )
      {
      }

      public string[] AcceptableValues
      {
         get;
         set;
      }

      public override object FromString( string argument )
      {
         return argument;
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<string>( (string) value, this.AcceptableValues );
      }
   }

   public class StringCompound : StringValue, ICompoundAttribute
   {
      private CompoundManager manager;

      public StringCompound( string prefix, string label )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, prefix, label );
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         set { base.Ordinal = value; }
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.manager.CaseSensitive; }
         set { this.manager.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.manager.Prefix; }
      }

      public string Label
      {
         get { return this.manager.Label; }
      }

      public string[] Aliases
      {
         get { return this.manager.Aliases; }
         set { this.manager.Aliases = value; }
      }

      #endregion

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }

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
            return System.IO.File.Exists( (string) convertedValue );
         }

         return true;
      }
   }

   public class FilePathCompound : FilePath, ICompoundAttribute
   {
      private CompoundManager manager;

      public FilePathCompound( string prefix, string label )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, prefix, label );
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.manager.CaseSensitive; }
         set { this.manager.CaseSensitive = value; }
      }

      public string Prefix
      {
         get { return this.manager.Prefix; }
      }

      public string Label
      {
         get { return this.manager.Label; }
      }

      public string[] Aliases
      {
         get { return this.manager.Aliases; }
         set { this.manager.Aliases = value; }
      }

      #endregion

      public override bool MatchArgument( string argument )
      {
         return this.manager.MatchArgument( argument );
      }
   }
}