using System;

namespace TestFramework
{
   //public delegate bool ActionBoolean();
   //public delegate string ActionString();
   //public delegate byte ActionByte();
   //public delegate UInt16 ActionUInt16();
   //public delegate UInt32 ActionUInt32();
   //public delegate UInt64 ActionUInt64();
   //public delegate sbyte ActionSByte();
   //public delegate Int16 ActionInt16();
   //public delegate Int32 ActionInt32();
   //public delegate Int64 ActionInt64();
   //public delegate float ActionFloat();
   //public delegate double ActionDouble();
   //public delegate DateTime ActionDateTime();
   //public delegate object ActionDateObject();
   public delegate T ActionT<T>();
}