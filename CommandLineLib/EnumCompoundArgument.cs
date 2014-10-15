using System;

namespace CommandLineLib
{
   public class EnumCompoundArgument<TEnum> : EnumArgument<TEnum>
      where TEnum : struct, IConvertible
   {
      private SwitchArgument @switch;

      public EnumCompoundArgument( PropertyAccessor property, IAttributeData attributeData, bool caseSensitive, string prefix, string label )
         : base( property, attributeData )
      {
         this.IsCompound = true;
         this.@switch = new SwitchArgument( property, attributeData, caseSensitive, prefix, label );
      }

      public bool CaseSensitive
      {
         get { return this.@switch.CaseSensitive; }
      }

      public string Prefix
      {
         get { return this.@switch.Prefix; }
      }

      public string Label
      {
         get { return this.@switch.Label; }
      }

      public override bool MatchCommandLineArgument( string value )
      {
         return this.@switch.MatchCommandLineArgument( value );
      }
   }
}
