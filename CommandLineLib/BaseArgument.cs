using System;

namespace CommandLineLib
{
   public interface IArgumentData
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

      string ShortName
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
   }

   public interface IProcessableArgument
   {
      bool MatchCommandLineArgument( string value );
      void SetFromCommandLineArgument( string value );
   }

   public interface IBaseArgument : IArgumentData, IProcessableArgument
   {
   }

   public abstract class BaseArgument : IBaseArgument
   {
      protected PropertyAccessor Property
      {
         get;
         private set;
      }

      public BaseArgument( PropertyAccessor propertyAccessor, IAttributeData attributeData )
      {
         this.Property = propertyAccessor;
         this.Ordinal = attributeData.Ordinal;
         this.Optional = attributeData.Optional;
         this.Groups = attributeData.Groups;
         this.Description = attributeData.Description;
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

      public string ShortName
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
