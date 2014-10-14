using System;
using System.Reflection;

namespace CommandLineLib
{
   public class EnumArgument<TEnum> : BaseArgument
      where TEnum : struct, IConvertible
   {
      public EnumArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description )
         : base( property, ordinal, optional, groups, description )
      {
      }

      public override bool MatchCommandLineArgument( string value )
      {
         TEnum result = default( TEnum );
         return Enum.TryParse<TEnum>( value, out result );
      }

      public override void SetFromCommandLineArgument( string value )
      {
         var result = Enum.Parse( typeof( TEnum ), value );

         if ( result == null )
         {
            throw new CommandLineException( String.Format( "The value \"{0}\" could not be converted to type \"{1}\".", value, typeof( TEnum ).Name ) );
         }

         this.Property.SetValue( (TEnum) result );
      }
   }
}