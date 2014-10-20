using System;
using System.Reflection;

namespace CommandLineLib
{
   [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property )]
   public abstract class BaseAttribute : System.Attribute, IBaseAttribute
   {
      public BaseAttribute()
      {
         this.Groups = new int[] { 0 };
      }

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

      public virtual string ShortName
      {
         get;
         set;
      }

      private string usageText;
      public virtual string UsageText
      {
         get
         {
            if ( String.IsNullOrEmpty( this.usageText ) )
            {
               this.usageText = String.Format( "{0}{1}{2}", this.Optional ? "[" : string.Empty, this.ShortName, this.Optional ? "]" : string.Empty );
            }

            return this.usageText;
         }
      }

      public bool IsCompound
      {
         get;
         protected set;
      }

      public virtual void SetProperty( PropertyInfo property )
      {
         if ( String.IsNullOrEmpty( this.ShortName ) )
         {
            this.ShortName = property.Name;
         }

         this.Property = property;
      }

      public abstract bool MatchArgument( string argument );

      public virtual bool SetArgument( object instance, string argument )
      {
         this.Property.SetValue( instance, argument );

         return true;
      }
   }
}
