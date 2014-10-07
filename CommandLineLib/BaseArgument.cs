using System;

namespace CommandLineLib
{
   public interface IBaseArgument
   {
      int Ordinal
      {
         get;
      }

      bool Optional
      {
         get;
      }

      int[] Groups
      {
         get;
      }

      string Description
      {
         get;
      }

      void SetFromCommandLineArgument( string value );

      bool WasSet
      {
         get;
         set;
      }
   }

   public abstract class BaseArgument : IBaseArgument
   {
      protected PropertyAccessor Property
      {
         get;
         private set;
      }

      public BaseArgument( PropertyAccessor propertyAccessor, int ordinal, bool optional, int[] groups, string description )
      {
         this.Property = propertyAccessor;
         this.Ordinal = ordinal;
         this.Optional = optional;
         this.Groups = groups;
         this.Description = description;
      }

      public int Ordinal
      {
         get;
         private set;
      }

      public bool Optional
      {
         get;
         private set;
      }

      public int[] Groups
      {
         get;
         private set;
      }

      public virtual string Description
      {
         get;
         private set;
      }

      public bool WasSet
      {
         get;
         set;
      }

      public virtual void SetFromCommandLineArgument( string value )
      {
         this.Property.SetValue( this.FromString( value ) );
         this.WasSet = true;
      }
      
      protected abstract object FromString( string value );
   }
}
