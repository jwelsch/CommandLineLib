using System;

namespace CommandLineLib
{
   public class StringValue : AcceptableValueBaseAttribute
   {
      public StringValue( int ordinal )
         : base( ordinal, typeof( String ) )
      {
      }

      public string[] AcceptableValues
      {
         get;
         set;
      }

      public override object FromString( string argument )
      {
         return argument;
      }

      protected override bool IsAcceptable( object value )
      {
         return RangeValueHelper.IsAcceptable<string>( (string) value, this.AcceptableValues );
      }
   }
}
