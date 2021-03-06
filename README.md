# C# Command Line Management Project
Handles parsing of command line arguments.
***
## Supported Argument Types  
* Switch argument: The presence of the switch acts as a boolean value.
    * Example: ```-foo```
* Value argument: Simply a value on the command line.
    * Example: ```"./etc/foo.config"``` or ```1```
* Compound argument: Consists of a switch followed by a value, separated by a space.
    * Example: ```-path "./etc/foo.config"``` or ```-iterations 1```
### Supported Options
* Case sensitivity
* Aliases
* Ordering
* Mutual exclusivity
* Optional/mandatory
* Acceptable values
***
## How To Use
The library revolves around the concept of a class containing decorated properties.  The raw command line arguments are parsed and their values are put into the decorated properties.  See the example code below.
***
## Attributes
There are many attributes that can be used based on the expected type of an argument.  The following are all the attributes that can be used to decorate properties so that they will be treated as arguments.
### ByteCompound
* Compound argument
* Property type: System.Byte
* Converts an argument to a System.Byte value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### ByteValue
* Value argument
* Property type: System.Byte
* Converts an argument to a System.Byte value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DateTimeCompound
* Compound argument
* Property type: System.DateTime
* Converts an argument to a System.DateTime value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DateTimeValue
* Value argument
* Property type: System.DateTime
* Converts an argument to a System.DateTime value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DecimalCompound
* Compound argument
* Property type: System.Decimal
* Converts an argument to a System.Decimal value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DecimalValue
* Value argument
* Property type: System.Decimal
* Converts an argument to a System.Decimal value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DirectoryCompound
* Value argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Indicator
* Optional: Aliases, CaseSensitive, Description, Groups, Must Exist, Optional, Ordinal, ShortName
### DirectoryPath
* Value argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Ordinal
* Optional: Description, Groups, MustExist, Optional, Ordinal, ShortName
### DoubleCompound
* Compound argument
* Property type: System.Double
* Converts an argument to a System.Double value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### DoubleValue
* Value argument
* Property type: System.Double
* Converts an argument to a System.Double value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### EnumCompound
* Compound argument
* Property type: Custom enumeration
* Converts an argument to a custom enumeration value.
* Non-optional: Indicator
* Optional: Aliases, CaseSensitive, Description, Groups, Optional, Ordinal, ShortName, ValueCaseSensitive
### EnumValue
* Value argument
* Property type: Custom enumeration
* Converts an argument to a custom enumeration value.
* Non-optional: Ordinal
* Optional: Description, Groups, Optional, Ordinal, ShortName, ValueCaseSensitive
### FilePathCompound
* Compound argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Indicator
* Optional: Aliases, CaseSensitive, Description, Groups, Must Exist, Optional, Ordinal, ShortName
### FilePath
* Value argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Ordinal
* Optional: Description, Groups, MustExist, Optional, Ordinal, ShortName
### Int16Compound
* Compound argument
* Property type: System.Int16
* Converts an argument to a System.Int16 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### Int16Value
* Value argument
* Property type: System.Int16
* Converts an argument to a System.Int16 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### Int32Compound
* Compound argument
* Property type: System.Int32
* Converts an argument to a System.Int32 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### Int32Value
* Value argument
* Property type: System.Int32
* Converts an argument to a System.Int32 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### Int64Compound
* Compound argument
* Property type: System.Int64
* Converts an argument to a System.Int64 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### Int64Value
* Value argument
* Property type: System.Int64
* Converts an argument to a System.Int64 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### SByteCompound
* Compound argument
* Property type: System.SByte
* Converts an argument to a System.SByte value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### SByteValue
* Value argument
* Property type: System.SByte
* Converts an argument to a System.SByte value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### SingleCompound
* Compound argument
* Property type: System.Single
* Converts an argument to a System.Single value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### SingleValue
* Value argument
* Property type: System.Single
* Converts an argument to a System.Single value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### StringCompound
* Compound argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Indicator
* Optional: Aliases, CaseSensitive, Description, Groups, Optional, Ordinal, ShortName
### StringValue
* Value argument
* Property type: System.String
* Converts an argument to a System.String value.
* Non-optional: Ordinal
* Optional: Description, Groups, Optional, Ordinal, ShortName
### Switch
* Switch argument
* Property type: System.Boolean
* If present, the property is set to true (or false if Reverse is set to true).
* Non-optional: Indicator
* Optional: Aliases, CaseSensitive, Description, Groups, Optional, Ordinal, ShortName, Reverse
### UInt16Compound
* Compound argument
* Property type: System.UInt16
* Converts an argument to a System.UInt16 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### UInt16Value
* Value argument
* Property type: System.UInt16
* Converts an argument to a System.UInt16 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### UInt32Compound
* Compound argument
* Property type: System.UInt32
* Converts an argument to a System.UInt32 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### UInt32Value
* Value argument
* Property type: System.UInt32
* Converts an argument to a System.UInt32 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### UInt64Compound
* Compound argument
* Property type: System.UInt64
* Converts an argument to a System.UInt64 value.
* Non-optional: Indicator
* Optional: Aliases, AcceptableValues, CaseSensitive, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
### UInt64Value
* Value argument
* Property type: System.UInt64
* Converts an argument to a System.UInt64 value.
* Non-optional: Ordinal
* Optional: AcceptableValues, Description, Groups, Optional, Ordinal, RangeMax, RangeMin, ShortName
***
## Named Parameters
Named parameters are what are passed into the constructor of the attribute.  The following are the supported named parameters.  Note that not all named parameters are supported by all attributes.
### AcceptableValues
An array of the only values that the argument can be.  By default all values are acceptable.
### Aliases
An array of identifiers that can refer to a switch or compound argument in addition to it its formal identifier.  By default there are no aliases.
### Description
Description of the argument.  Used in generating help.  Empty string by default.
### CaseSensitive
Setting to True will make the Indicators on switch and compound arguments case sensitive.  If False they will not be case sensitive.  Defaults to False.
### Groups
Used to make arguments mutually exclusive.  Array of integers that represent groups that the argument can belong to.  A group can be designated by any integer.  If zero is specified, the argument belongs to all groups.  If no group is specified the argument is assigned zero for a group and belongs to all groups.  Arguments can belong to multiple groups.  Arguments in the same group are allowed to be specified together on the command line.  Arguments NOT in the same group are not allowed to be specified together on the command line.  
  
Non-optional arguments are mandatory within their assigned group.  So, if an argument is mandatory and in group 1, but arguments for group 2 were passed on the command line, no exceptions would be thrown.  
  
Defaults to zero.
  
Example:  

* -a (group 1)
* -b (group 2)
* -c (group 1)
* -d (no group specified)  

Allowed:  ```app.exe -a -c -d```  
Not allowed (because -a and -b belong to different groups):  ```app.exe -a -b -d```
### Identifier
Used to identify a switch or compound argument.  Must be unique.
### MustExist
The file or directory must exist on the file system.  Defaults to False.
### Optional
Marks an argument as optional.  Switch arguments can be optional without restrictions.  An optional value argument cannot be followed by any required parameters unless they are separated by a switch argument.  In this case the switch argument must have an ordinal.  
  
Non-optional arguments are mandatory within their assigned group.  So, if an argument is mandatory and in group 1, but arguments for group 2 were passed on the command line, no exceptions would be thrown.  
  
Defaults to False.
  
Legal Example:  

* value1 (Ordinal = 1, Optional = false)
* value2 (Ordinal = 2, Optional = true)
* value3 (Ordinal = 3, Optional = true)
* -a     (Ordinal = 4, Optional = false)
* value4 (Ordinal = 5, Optional = false)  

Illegal Example:  

* value1 (Ordinal = 1, Optional = false)
* value2 (Ordinal = 2, Optional = true)
* value3 (Ordinal = 3, Optional = false)  
### Ordinal
Specified the order that the argument should appear on the command line.  Zero or less is any order.  Greater than zero means the argument should appear in that order (ascending).  If no ordinal is specified, the default is zero.  Multiple switch or compound arguments can have the same ordinal.  Those with the same ordinal can be in any order within that ordinal number.  Only one argument (switch or value) can have a specific ordinal if that ordinal is assigned to a value argument.  Defaults to zero.
### RangeMax
The maximum (inclusive) allowed value of a value argument.  Defaults to system minimum value for that type.
### RangeMin
The minimum (inclusive) allowed value of a value argument.  Defaults to system maximum value for that type.
### Reverse
Reverses the final value of a switch.  Normally, if a switch is found on the command line, it's corresponding property is set to true.  If Reverse is set to true, when the switch is found on the command line, the corresponding property is set to false.  For best results, be sure to set the property to true in the containing class's constructor.
### ShortName
A short descriptor for the argument.  Used in generating help.  Defaults to the Indicator for switches and compounds.  For values it defaults to the name of the property.
### ValueCaseSensitive
Setting to True will make the values on EnumValue and EnumCompound arguments case sensitive.  If False they will not be case sensitive.  Defaults to False.
***
## Automatically Generated Help
CommandLineLib can automatically generate command line usage help text.  Make sure that the arguments have at least the Description named parameter set.  For best results, set the ShortName named parameter for value arguments, as well (switch and compound arguments default to using their Identifier).
  
The help text is generated by calling the instance method CommandLine<T>.Help().  The generated text can then be written to the Console or elsewhere.
  
There are three overrides.  All automatically retrieved values are done so by using Assembly.GetEntryAssembly().
  
- ```string Help()```  The assembly file name and version are automatically retrieved.
- ```string Help( string assemblyFileName )```  This takes the assembly file name, while the assembly version is automatically retrieved.
- ```string Help( string assemblyFileName, Version assemblyVersion )```  The third takes the assembly file name and the assembly version.
  
See the example code below.
***
## Classes
### General
#### CommandLine
Class that must be given the class that contains properties decorated with argument attributes as a type parameter in its constructor.  If construction is complete, then call Parse() and pass in the raw command line arguments that were passed into main().
### Exceptions
#### AmbiguousArgumentException
Thrown when a required value argument is directly followed by an optional value argument.
#### ArgumentFormatException
Thrown when a value cannot be formatted to its specified type.
#### ArgumentNotFoundException
Thrown when a mandatory argument was not detected.
#### ArgumentOutOfOrderException
Thrown when arguments are passed out of order as specified by their Ordinals.
#### ArgumentTypeMismatchException
Thrown when the type expected by an argument attribute does not match the type specified for its property.
#### BadIdentifierException
Thrown when an identifier or alias is not correctly formatted or contains invalid characters.
#### CompoundArgumentValueMissingException
Thrown when the value part of a compound argument is missing.
#### DuplicateArgumentException
Thrown when the same argument is present more than once in the command line arguments.
#### DuplicateIdentifierException
Thrown when the identifier or aliases of an argument are not unique.
#### DuplicateOrdinalException
Thrown when multiple arguments are declared with the same ordinal.
#### GroupNotAllowedException
Thrown when a group not that is not allowed due to previous group(s) being present is in the command line arguments.
#### InvalidMemberException
Thrown when a member that is not a property is decorated with a command line argument attribute.
#### NoCommandLineAttributesFoundException
Thrown when no command line attributes are found on the class passed as the type parameter to the CommandLine constructor.
#### SharedIdentifierException
Thrown when multiple arguments have the same identifier or alias.
#### UnknownAttributeException
Thrown when an unknown command line attribute type is encountered.
#### ValueNotAcceptableException
Thrown when a value is not found in the acceptable values for an argument.
#### ValueOutOfRangeException
Thrown when a value is found to be out of the specified range for an argument.
***
## Example Code
```
using CommandLineLib;

public class Arguments
{
   [Int32Value( 1, RangeMin = 0, RangeMax = 100 )]
   public Int32 Value1
   {
      get;
      private set;
   }
   
   [Switch( "-foo" )]
   public bool Foo
   {
      get;
      private set;
   }
   
   [StringCompound( "-bar" )]
   public string Compound1
   {
      get;
      private set;
   }
}

public class Program
{
   static void main( string[] args )
   {
      CommandLine commandLine = null;
      try
      {
         commandLine = new CommandLine<Arguments>();
         var arguments = commandLine.Parse( args );
      }
      catch ( CommandLineException ex )
      {
         System.Diagnostics.Trace.WriteLine( ex );
         if ( commandLine != null )
         {
            Console.WriteLine( commandLine.Help() );
         }
      }
   }
}
```