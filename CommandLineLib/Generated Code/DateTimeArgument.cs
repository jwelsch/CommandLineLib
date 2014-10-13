using System;

namespace CommandLineLib
{
   public class DateTimeValueArgument : ValueArgument<DateTime>
   {
      public DateTimeValueArgument( PropertyAccessor property, int ordinal, bool optional, int[] groups, string description, DateTime[] acceptableValues, DateTime rangeMin, DateTime rangeMax )
         : base( property, ordinal, optional, groups, description, acceptableValues )
      {
      }
   }
}

