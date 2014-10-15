using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CommandLineLib
{
   /**************************************************************************
    * 
    * Command Line Syntax Key
    *   (Credit: http://technet.microsoft.com/en-us/library/cc771080.aspx)
    * 
    *  Notation                       | Description
    * ================================+======================================
    * Text without brackets or braces | Items must be typed as shown
    * --------------------------------+--------------------------------------
    * <Text inside angle brackets>    | Placeholder for values that must be
    *                                 | supplied
    * --------------------------------+--------------------------------------
    * [Text inside square brackets]   | Optional items
    * --------------------------------+--------------------------------------
    * {Text inside braces}            | Set of required items; choose one
    * --------------------------------+--------------------------------------
    * Vertical bar (|)                | Separator for mutually exclusive
    *                                 | items; choose one
    * --------------------------------+--------------------------------------
    * Ellipsis (...)                  | Items that can be repeated
    * --------------------------------+--------------------------------------
    * 
    * ***********************************************************************/

   public class CommandLineUsage
   {
      public class Group
      {
         public int Identifier
         {
            get;
            private set;
         }

         public List<IBaseAttribute> Attributes
         {
            get;
            private set;
         }

         public Group( int identifier )
         {
            this.Identifier = identifier;
            this.Attributes = new List<IBaseAttribute>();
         }
      }

      public string Generate( IEnumerable<IBaseAttribute> attributes )
      {
         var text = new StringBuilder( "Command line usage:" );
         text.AppendLine();
         text.Append( "   " );
         text.Append( Path.GetFileName( Assembly.GetExecutingAssembly().Location ) );

         foreach ( var attribute in attributes )
         {
            text.Append( " " );
         }

         return text.ToString();
      }

      private List<Group> ByGroups( IEnumerable<IBaseAttribute> attributes )
      {
         var groups = new List<Group>();

         foreach ( var attribute in attributes )
         {
            foreach ( var groupId in attribute.Groups )
            {
               var i = groups.FindIndex( ( item ) =>
               {
                  return ( item.Identifier == groupId );
               } );

               if ( i > 0 )
               {
                  groups[i].Attributes.Add( attribute );
               }
               else
               {
                  var g = new Group( groupId );
                  g.Attributes.Add( attribute );
                  groups.Add( g );
               }
            }
         }

         return groups;
      }
   }
}
