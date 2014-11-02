using System;

namespace CommandLineLib
{
   #region CommandLineException

   /// <summary>
   /// Thrown when there is an error encountered with processing the command line arguments.
   /// </summary>
   [Serializable]
   public class CommandLineException : Exception
   {
      /// <summary>
      /// Constructs an object of type CommandLineException.
      /// </summary>
      public CommandLineException()
      {
      }

      /// <summary>
      /// Constructs an object of type CommandLineException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public CommandLineException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type CommandLineException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the CommandLineException.</param>
      public CommandLineException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a CommandLineException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected CommandLineException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region GroupNotAllowedException

   /// <summary>
   /// Thrown when a group not that is not allowed due to previous group(s) being present is in the command line arguments.
   /// </summary>
   [Serializable]
   public class GroupNotAllowedException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type GroupNotAllowedException.
      /// </summary>
      public GroupNotAllowedException()
      {
      }

      /// <summary>
      /// Constructs an object of type GroupNotAllowedException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public GroupNotAllowedException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type GroupNotAllowedException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the GroupNotAllowedException.</param>
      public GroupNotAllowedException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a GroupNotAllowedException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected GroupNotAllowedException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ArgumentOutOfOrderException

   /// <summary>
   /// Thrown when arguments are passed out of order as specified by their Ordinals.
   /// </summary>
   [Serializable]
   public class ArgumentOutOfOrderException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type ArgumentOutOfOrderException.
      /// </summary>
      public ArgumentOutOfOrderException()
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentOutOfOrderException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ArgumentOutOfOrderException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentOutOfOrderException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ArgumentOutOfOrderException.</param>
      public ArgumentOutOfOrderException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ArgumentOutOfOrderException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ArgumentOutOfOrderException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region CompoundArgumentValueMissingException

   /// <summary>
   /// Thrown when the value part of a compound argument is missing.
   /// </summary>
   [Serializable]
   public class CompoundArgumentValueMissingException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type CompoundArgumentValueMissingException.
      /// </summary>
      public CompoundArgumentValueMissingException()
      {
      }

      /// <summary>
      /// Constructs an object of type CompoundArgumentValueMissingException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public CompoundArgumentValueMissingException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type CompoundArgumentValueMissingException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the CompoundArgumentValueMissingException.</param>
      public CompoundArgumentValueMissingException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a CompoundArgumentValueMissingException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected CompoundArgumentValueMissingException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region DuplicateArgumentException

   /// <summary>
   /// Thrown when the same argument is present more than once in the command line arguments.
   /// </summary>
   [Serializable]
   public class DuplicateArgumentException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type DuplicateArgumentException.
      /// </summary>
      public DuplicateArgumentException()
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public DuplicateArgumentException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the DuplicateArgumentException.</param>
      public DuplicateArgumentException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a DuplicateArgumentException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected DuplicateArgumentException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ArgumentNotFoundException

   /// <summary>
   /// Thrown when a mandatory argument was not detected.
   /// </summary>
   [Serializable]
   public class ArgumentNotFoundException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type ArgumentNotFoundException.
      /// </summary>
      public ArgumentNotFoundException()
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentNotFoundException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ArgumentNotFoundException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentNotFoundException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ArgumentNotFoundException.</param>
      public ArgumentNotFoundException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ArgumentNotFoundException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ArgumentNotFoundException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ValueNotAcceptableException

   /// <summary>
   /// Thrown when a value is not found in the acceptable values for an argument.
   /// </summary>
   [Serializable]
   public class ValueNotAcceptableException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type ValueNotAcceptableException.
      /// </summary>
      public ValueNotAcceptableException()
      {
      }

      /// <summary>
      /// Constructs an object of type ValueNotAcceptableException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ValueNotAcceptableException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ValueNotAcceptableException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ValueNotAcceptableException.</param>
      public ValueNotAcceptableException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ValueNotAcceptableException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ValueNotAcceptableException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ArgumentFormatException

   /// <summary>
   /// Thrown when a value cannot be formatted to its specified type.
   /// </summary>
   [Serializable]
   public class ArgumentFormatException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type ArgumentFormatException.
      /// </summary>
      public ArgumentFormatException()
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentFormatException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ArgumentFormatException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentFormatException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ArgumentFormatException.</param>
      public ArgumentFormatException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ArgumentFormatException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ArgumentFormatException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ValueOutOfRangeException

   /// <summary>
   /// Thrown when a value is found to be out of the specified range for an argument.
   /// </summary>
   [Serializable]
   public class ValueOutOfRangeException : CommandLineException
   {
      /// <summary>
      /// Constructs an object of type ValueOutOfRangeException.
      /// </summary>
      public ValueOutOfRangeException()
      {
      }

      /// <summary>
      /// Constructs an object of type ValueOutOfRangeException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ValueOutOfRangeException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ValueOutOfRangeException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ValueOutOfRangeException.</param>
      public ValueOutOfRangeException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ValueOutOfRangeException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ValueOutOfRangeException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region ArgumentTypeMismatchException

   /// <summary>
   /// Thrown when the type expected by an argument attribute does not match the type specified for its property.
   /// </summary>
   [Serializable]
   public class ArgumentTypeMismatchException : Exception
   {
      /// <summary>
      /// Constructs an object of type ArgumentTypeMismatchException.
      /// </summary>
      public ArgumentTypeMismatchException()
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentTypeMismatchException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public ArgumentTypeMismatchException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type ArgumentTypeMismatchException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the ArgumentTypeMismatchException.</param>
      public ArgumentTypeMismatchException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a ArgumentTypeMismatchException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected ArgumentTypeMismatchException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion
}
