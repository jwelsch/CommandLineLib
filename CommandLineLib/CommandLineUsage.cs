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

      public class GroupText
      {
         public string UsageText
         {
            get;
            private set;
         }

         public string DescriptionText
         {
            get;
            private set;
         }

         public GroupText( string usageText, string descriptionText )
         {
            this.UsageText = usageText;
            this.DescriptionText = descriptionText;
         }
      }

      public string Generate( IEnumerable<IBaseAttribute> attributes )
      {
         var descriptionText = new StringBuilder();
         var usageText = new StringBuilder( "Command line usage:" );
         usageText.AppendLine();
         usageText.Append( "   " );
         usageText.Append( Path.GetFileName( Assembly.GetExecutingAssembly().Location ) );

         var sortedGroups = this.SortByGroups( attributes );
         var groupCount = 0;

         foreach ( var group in sortedGroups )
         {
            var groupText = this.GenerateGroup( group );

            if ( group.Identifier == 0 )
            {
               if ( groupCount == 0 )
               {
                  usageText.AppendFormat( " {0}", groupText.UsageText );
               }
               else
               {
                  usageText.AppendFormat( "{0}", groupText.UsageText );
               }
            }
            else
            {
               if ( groupCount == 1 )
               {
                  usageText.AppendFormat( " {{{0}}}", groupText.UsageText );
               }
               else
               {
                  usageText.AppendFormat( "|{{{0}}}", groupText.UsageText );
               }
            }

            descriptionText.Append( groupText.DescriptionText );

            groupCount++;
         }

         usageText.AppendLine();
         usageText.AppendLine();
         usageText.Append( descriptionText.ToString() );

         return usageText.ToString();
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

               if ( i >= 0 )
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

      private IEnumerable<Group> SortByGroups( IEnumerable<IBaseAttribute> attributes )
      {
         var groups = this.ByGroups( attributes );

         groups.Sort( ( item1, item2 ) =>
            {
               if ( item1.Identifier < item2.Identifier )
               {
                  return -1;
               }
               else if ( item1.Identifier > item2.Identifier )
               {
                  return 1;
               }

               return 0;
            } );

         return groups;
      }

      private GroupText GenerateGroup( Group group )
      {
         group.Attributes.Sort( ( item1, item2 ) =>
            {
               if ( item1.Ordinal < item2.Ordinal )
               {
                  return -1;
               }
               else if ( item1.Ordinal > item2.Ordinal )
               {
                  return 1;
               }

               return 0;
            } );

         var usageText = new StringBuilder();
         var descriptionText = new StringBuilder();
         var count = 0;

         foreach ( var attribute in group.Attributes )
         {
            if ( attribute.Optional )
            {
               usageText.AppendFormat( "{0}[{1}]", count == 0 ? string.Empty : " ",  attribute.Usage() );
            }
            else
            {
               usageText.AppendFormat( "{0}{1}", count == 0 ? string.Empty : " ", attribute.Usage() );
            }

            descriptionText.AppendLine( String.Format( "{0}: {1}", attribute.ShortName, attribute.Description ) );
            count++;
         }

         return new GroupText( usageText.ToString(), descriptionText.ToString() );
      }
   }
}
