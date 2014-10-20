using System;
using System.Reflection;

namespace CommandLineLib
{
   public interface IBaseAttribute
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

      string UsageText
      {
         get;
      }

      bool IsCompound
      {
         get;
      }

      void SetProperty( PropertyInfo property );
      bool MatchArgument( string argument );
      bool SetArgument( object instance, string argument );
   }

   public interface ISwitchAttribute : IBaseAttribute
   {
      bool CaseSensitive
      {
         get;
         set;
      }

      string Identifier
      {
         get;
      }

      string[] Aliases
      {
         get;
      }
   }

   //
   // NOTE: Values will need to be created dynamically
   //

   public interface IValueAttribute : IBaseAttribute
   {
   }

   public interface IAcceptableValueAttribute : IValueAttribute
   {
   }

   public interface IRangeValueAttribute : IAcceptableValueAttribute
   {
   }

   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   public interface IAcceptableCompoundAttribute : ICompoundAttribute, IAcceptableValueAttribute
   {
   }

   public interface IRangeCompoundAttribute : IAcceptableCompoundAttribute, IRangeValueAttribute
   {
   }
}