using System;

namespace CommandLineLib
{
   #region CommandLineDeclarationException

   /// <summary>
   /// Thrown when a command line argument is not declared correctly in a class.
   /// </summary>
   [Serializable]
   public class CommandLineDeclarationException : Exception
   {
      /// <summary>
      /// Constructs an object of type CommandLineDeclarationException.
      /// </summary>
      public CommandLineDeclarationException()
      {
      }

      /// <summary>
      /// Constructs an object of type CommandLineDeclarationException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public CommandLineDeclarationException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type CommandLineDeclarationException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the CommandLineDeclarationException.</param>
      public CommandLineDeclarationException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a CommandLineDeclarationException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected CommandLineDeclarationException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region InvalidMemberException

   /// <summary>
   /// Thrown when a member that is not a property is decorated with a command line argument attribute.
   /// </summary>
   [Serializable]
   public class InvalidMemberException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type InvalidMemberException.
      /// </summary>
      public InvalidMemberException()
      {
      }

      /// <summary>
      /// Constructs an object of type InvalidMemberException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public InvalidMemberException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type InvalidMemberException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the InvalidMemberException.</param>
      public InvalidMemberException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a InvalidMemberException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected InvalidMemberException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region NoCommandLineAttributesFoundException

   /// <summary>
   /// Thrown when no command line attributes are found on the class passed as the type parameter to the CommandLine constructor.
   /// </summary>
   [Serializable]
   public class NoCommandLineAttributesFoundException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type NoCommandLineAttributesFoundException.
      /// </summary>
      public NoCommandLineAttributesFoundException()
      {
      }

      /// <summary>
      /// Constructs an object of type NoCommandLineAttributesFoundException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public NoCommandLineAttributesFoundException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type NoCommandLineAttributesFoundException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the NoCommandLineAttributesFoundException.</param>
      public NoCommandLineAttributesFoundException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a NoCommandLineAttributesFoundException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected NoCommandLineAttributesFoundException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region DuplicateOrdinalException

   /// <summary>
   /// Thrown when multiple arguments are declared with the same ordinal.
   /// </summary>
   [Serializable]
   public class DuplicateOrdinalException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type DuplicateOrdinalException.
      /// </summary>
      public DuplicateOrdinalException()
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateOrdinalException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public DuplicateOrdinalException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateOrdinalException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the DuplicateOrdinalException.</param>
      public DuplicateOrdinalException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a DuplicateOrdinalException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected DuplicateOrdinalException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region AmbiguousArgumentException

   /// <summary>
   /// Thrown when a required value argument is directly followed by an optional value argument.
   /// </summary>
   [Serializable]
   public class AmbiguousArgumentException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type AmbiguousArgumentException.
      /// </summary>
      public AmbiguousArgumentException()
      {
      }

      /// <summary>
      /// Constructs an object of type AmbiguousArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public AmbiguousArgumentException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type AmbiguousArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the AmbiguousArgumentException.</param>
      public AmbiguousArgumentException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a AmbiguousArgumentException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected AmbiguousArgumentException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region UnknownAttributeException

   /// <summary>
   /// Thrown when an unknown command line attribute type is encountered.
   /// </summary>
   [Serializable]
   public class UnknownAttributeException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type UnknownAttributeException.
      /// </summary>
      public UnknownAttributeException()
      {
      }

      /// <summary>
      /// Constructs an object of type UnknownAttributeException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public UnknownAttributeException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type UnknownAttributeException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the UnknownAttributeException.</param>
      public UnknownAttributeException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a UnknownAttributeException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected UnknownAttributeException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region DuplicateAliasException

   /// <summary>
   /// Thrown when the identifier or aliases of an argument are not unique.
   /// </summary>
   [Serializable]
   public class DuplicateIdentifierException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type DuplicateAliasException.
      /// </summary>
      public DuplicateIdentifierException()
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateAliasException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public DuplicateIdentifierException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type DuplicateAliasException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the DuplicateAliasException.</param>
      public DuplicateIdentifierException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a DuplicateAliasException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected DuplicateIdentifierException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region SharedIdentifierException

   /// <summary>
   /// Thrown when multiple arguments have the same identifier or alias.
   /// </summary>
   [Serializable]
   public class SharedIdentifierException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type SharedIdentifierException.
      /// </summary>
      public SharedIdentifierException()
      {
      }

      /// <summary>
      /// Constructs an object of type SharedIdentifierException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public SharedIdentifierException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type SharedIdentifierException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the SharedIdentifierException.</param>
      public SharedIdentifierException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a SharedIdentifierException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected SharedIdentifierException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion

   #region BadIdentifierException

   /// <summary>
   /// Thrown when an identifier or alias is not correctly formatted or contains invalid characters.
   /// </summary>
   [Serializable]
   public class BadIdentifierException : CommandLineDeclarationException
   {
      /// <summary>
      /// Constructs an object of type BadIdentifierException.
      /// </summary>
      public BadIdentifierException()
      {
      }

      /// <summary>
      /// Constructs an object of type BadIdentifierException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public BadIdentifierException( string message )
         : this( message, null )
      {
      }

      /// <summary>
      /// Constructs an object of type BadIdentifierException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the BadIdentifierException.</param>
      public BadIdentifierException( string message, Exception innerException )
         : base( message, innerException )
      {
      }

      /// <summary>
      /// Constructs a BadIdentifierException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected BadIdentifierException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }

   #endregion
}
