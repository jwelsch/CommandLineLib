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

      bool IsCompound
      {
         get;
      }

      bool WasSet
      {
         get;
      }

      bool MatchCommandLineArgument( string value );
      void SetFromCommandLineArgument( string value );
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

      public bool IsCompound
      {
         get;
         protected set;
      }

      public bool WasSet
      {
         get { return this.Property.WasSet; }
      }

      public abstract bool MatchCommandLineArgument( string value );
      public abstract void SetFromCommandLineArgument( string value );
   }
}
