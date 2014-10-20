using System;

namespace CommandLineLib
{
   public class FilePathCompound : FilePath, ICompoundAttribute
   {
      private CompoundManager manager;

      public FilePathCompound( string identifier )
         : base( 0 )
      {
         this.manager = new CompoundManager( this, identifier );
      }

      #region ISwitchAttribute Members

      public bool CaseSensitive
      {
         get { return this.manager.CaseSensitive; }
         set { this.manager.CaseSensitive = value; }
      }

      public string Identifier
      {
         get { return this.manager.Identifier; }
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