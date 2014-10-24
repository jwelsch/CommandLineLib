using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CommandLineLib
{
   internal static class AssemblyData
   {
      public static Version AssemblyVersion
      {
         get;
         private set;
      }

      public static FileVersionInfo FileVersion
      {
         get;
         private set;
      }

      public static string AssemblyName
      {
         get;
         private set;
      }

      public static string FilePath
      {
         get;
         private set;
      }

      public static string DirectoryPath
      {
         get;
         private set;
      }

      public static string FileName
      {
         get;
         private set;
      }

      static AssemblyData()
      {
         var assembly = Assembly.GetEntryAssembly();

         AssemblyData.FilePath = assembly.Location;
         AssemblyData.DirectoryPath = Path.GetDirectoryName( AssemblyData.FilePath );
         AssemblyData.FileName = Path.GetFileName( assembly.Location );

         AssemblyData.AssemblyName = assembly.FullName;
         AssemblyData.AssemblyVersion = assembly.GetName().Version;
         AssemblyData.FileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo( AssemblyData.FilePath );
      }
   }
}
