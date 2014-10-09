using System;

namespace CommandLineLib
{
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
}
