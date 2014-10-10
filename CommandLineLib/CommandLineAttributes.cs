using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CommandLineLib
{
   public interface IBaseAttribute
   {
      /// <summary>
      /// <=0 is any order.
      /// >0 is ascending order.
      /// If no ordinal is specified, the default is 0.
      /// Can have multiple switch arguments with the same ordinal.  Those with
      /// the same ordinal can be in any order within that ordinal number.
      /// Only one argument (switch or value) can have a specific ordinal if
      /// that ordinal is assigned to a value argument.
      /// </summary>
      int Ordinal
      {
         get;
      }

      /// <summary>
      /// Switch arguments can be optional without restrictions.
      /// An optional value argument cannot be followed by any required
      /// parameters unless they are separated by a switch argument.  In this
      /// case the switch argument must have an ordinal.
      /// 
      /// Legal Example:
      ///   value1 (Ordinal = 1, Optional = false)
      ///   value2 (Ordinal = 2, Optional = true)
      ///   value3 (Ordinal = 3, Optional = true)
      ///   -a     (Ordinal = 4, Optional = false)
      ///   value4 (Ordinal = 5, Optional = false)
      /// 
      /// Illegal Example:
      ///   value1 (Ordinal = 1, Optional = false)
      ///   value2 (Ordinal = 2, Optional = true)
      ///   value3 (Ordinal = 3, Optional = false)
      /// </summary>
      bool Optional
      {
         get;
      }

      /// <summary>
      /// Can be any integer.
      /// Can belong to multiple groups.
      /// If no group is specified, the default is to only belong to the 0
      /// group.
      /// Arguments in the same group are allowed to be specified together on
      /// the command line.  Arguments NOT in the same group are not allowed to
      /// be specified together on the command line.
      /// 
      /// Example:
      ///   -a (group 1)
      ///   -b (group 2)
      ///   -c (group 1)
      ///   
      /// Allowed:
      ///   app.exe -a -c
      ///   
      /// Not allowed:
      ///   app.exe -a -b
      /// </summary>
      int[] Groups
      {
         get;
      }

      string Description
      {
         get;
      }

      IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
      bool CheckPropertyType( PropertyInfo propertyInfo );
   }

   public abstract class BaseAttribute : System.Attribute, IBaseAttribute
   {
      public BaseAttribute()
      {
         this.Groups = new int[] { 0 };
      }

      private int ordinal;
      public int Ordinal
      {
         get { return this.ordinal; }
         set { this.ordinal = ( value < 0 ? 0 : value ); }
      }

      public bool Optional
      {
         get;
         set;
      }

      public int[] Groups
      {
         get;
         set;
      }

      public virtual string Description
      {
         get;
         set;
      }

      public abstract IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo );
      public abstract bool CheckPropertyType( PropertyInfo propertyInfo );
   }

   public interface ISwitchAttribute : IBaseAttribute
   {
      bool CaseSensitive
      {
         get;
         set;
      }

      string Prefix
      {
         get;
      }

      string Label
      {
         get;
      }
   }

   public class Switch : BaseAttribute, ISwitchAttribute
   {
      public Switch( string prefix, string label )
      {
         this.Prefix = prefix;
         this.Label = label;
      }

      public bool CaseSensitive
      {
         get;
         set;
      }

      public string Prefix
      {
         get;
         private set;
      }

      public string Label
      {
         get;
         private set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SwitchArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.CaseSensitive, this.Prefix, this.Label );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Boolean ) );
      }
   }

   public interface IValueAttribute : IBaseAttribute
   {
   }

   public abstract class Value : BaseAttribute, IValueAttribute
   {
      public Value( int ordinal )
      {
         this.Ordinal = ordinal;
      }

      public new int Ordinal
      {
         get { return base.Ordinal; }
         private set { base.Ordinal = value; }
      }
   }

   public class StringValue : Value
   {
      public StringValue( int ordinal )
         : base( ordinal )
      {
      }

      public String[] AcceptableValues
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new StringValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( String ) );
      }
   }

   public interface IRangeValueAttribute : IValueAttribute
   {
   }

   public abstract class RangeValue : Value, IRangeValueAttribute
   {
      public RangeValue( int ordinal )
         : base( ordinal )
      {
      }
   }

   public class SByteValue : RangeValue
   {
      public SByteValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = SByte.MinValue;
         this.RangeMax = SByte.MaxValue;
      }

      public SByte[] AcceptableValues
      {
         get;
         set;
      }

      public SByte RangeMin
      {
         get;
         set;
      }

      public SByte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( SByte ) );
      }
   }

   public class Int16Value : RangeValue
   {
      public Int16Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int16.MinValue;
         this.RangeMax = Int16.MaxValue;
      }

      public Int16[] AcceptableValues
      {
         get;
         set;
      }

      public Int16 RangeMin
      {
         get;
         set;
      }

      public Int16 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int16 ) );
      }
   }

   public class Int32Value : RangeValue
   {
      public Int32Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int32.MinValue;
         this.RangeMax = Int32.MaxValue;
      }

      public Int32[] AcceptableValues
      {
         get;
         set;
      }

      public Int32 RangeMin
      {
         get;
         set;
      }

      public Int32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int32 ) );
      }
   }

   public class Int64Value : RangeValue
   {
      public Int64Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Int64.MinValue;
         this.RangeMax = Int64.MaxValue;
      }

      public Int64[] AcceptableValues
      {
         get;
         set;
      }

      public Int64 RangeMin
      {
         get;
         set;
      }

      public Int64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new Int64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Int64 ) );
      }
   }

   public class ByteValue : RangeValue
   {
      public ByteValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Byte.MinValue;
         this.RangeMax = Byte.MaxValue;
      }

      public Byte[] AcceptableValues
      {
         get;
         set;
      }

      public Byte RangeMin
      {
         get;
         set;
      }

      public Byte RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new ByteValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Byte ) );
      }
   }

   public class UInt16Value : RangeValue
   {
      public UInt16Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt16.MinValue;
         this.RangeMax = UInt16.MaxValue;
      }

      public UInt16[] AcceptableValues
      {
         get;
         set;
      }

      public UInt16 RangeMin
      {
         get;
         set;
      }

      public UInt16 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt16ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt16 ) );
      }
   }

   public class UInt32Value : RangeValue
   {
      public UInt32Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt32.MinValue;
         this.RangeMax = UInt32.MaxValue;
      }

      public UInt32[] AcceptableValues
      {
         get;
         set;
      }

      public UInt32 RangeMin
      {
         get;
         set;
      }

      public UInt32 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt32ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt32 ) );
      }
   }

   public class UInt64Value : RangeValue
   {
      public UInt64Value( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = UInt64.MinValue;
         this.RangeMax = UInt64.MaxValue;
      }

      public UInt64[] AcceptableValues
      {
         get;
         set;
      }

      public UInt64 RangeMin
      {
         get;
         set;
      }

      public UInt64 RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new UInt64ValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( UInt64 ) );
      }
   }

   public class SingleValue : RangeValue
   {
      public SingleValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Single.MinValue;
         this.RangeMax = Single.MaxValue;
      }

      public Single[] AcceptableValues
      {
         get;
         set;
      }

      public Single RangeMin
      {
         get;
         set;
      }

      public Single RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new SingleValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Single ) );
      }
   }

   public class DoubleValue : RangeValue
   {
      public DoubleValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Double.MinValue;
         this.RangeMax = Double.MaxValue;
      }

      public Double[] AcceptableValues
      {
         get;
         set;
      }

      public Double RangeMin
      {
         get;
         set;
      }

      public Double RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DoubleValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Double ) );
      }
   }

   public class DecimalValue : RangeValue
   {
      public DecimalValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = Decimal.MinValue;
         this.RangeMax = Decimal.MaxValue;
      }

      public Decimal[] AcceptableValues
      {
         get;
         set;
      }

      public Decimal RangeMin
      {
         get;
         set;
      }

      public Decimal RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DecimalValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( Decimal ) );
      }
   }

   public class DateTimeValue : RangeValue
   {
      public DateTimeValue( int ordinal )
         : base( ordinal )
      {
         this.RangeMin = DateTime.MinValue;
         this.RangeMax = DateTime.MaxValue;
      }

      public DateTime[] AcceptableValues
      {
         get;
         set;
      }

      public DateTime RangeMin
      {
         get;
         set;
      }

      public DateTime RangeMax
      {
         get;
         set;
      }

      public override IBaseArgument CreateArgument( object instance, PropertyInfo propertyInfo )
      {
         return new DateTimeValueArgument( new PropertyAccessor( instance, propertyInfo ), this.Ordinal, this.Optional, this.Groups, this.Description, this.AcceptableValues, this.RangeMin, this.RangeMax );
      }

      public override bool CheckPropertyType( PropertyInfo propertyInfo )
      {
         return ( propertyInfo.PropertyType == typeof( DateTime ) );
      }
   }

   public interface ICompoundAttribute : ISwitchAttribute, IValueAttribute
   {
   }

   //public class Compound : ICompoundAttribute
   //{
   //   private Switch @switch;
   //   private Type valueType;

   //   public Compound( string prefix, string label )
   //   {
   //      this.@switch = new Switch( prefix, label );
   //   }

   //   public bool CaseSensitive
   //   {
   //      get { return this.@switch.CaseSensitive; }
   //      set { this.@switch.CaseSensitive = value; }
   //   }

   //   public string Prefix
   //   {
   //      get { return this.@switch.Prefix; }
   //   }

   //   public string Label
   //   {
   //      get { return this.@switch.Label; }
   //   }

   //   public override string Description
   //   {
   //      get { return this.@switch.Description; }
   //   }

   //   #region IBaseAttribute Members

   //   public int Ordinal
   //   {
   //      get { return this.@switch.Ordinal; }
   //   }

   //   public bool Optional
   //   {
   //      get { return this.@switch.Optional; }
   //   }

   //   public int[] Groups
   //   {
   //      get { return this.@switch.Groups; }
   //   }

   //   #endregion
   //}
}