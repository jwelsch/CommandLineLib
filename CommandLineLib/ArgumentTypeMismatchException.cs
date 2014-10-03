using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineLib
{
   /// <summary>
   /// Thrown when the type of a parameter of a value argument does not match.
   /// </summary>
   [Serializable]
   internal class ArgumentTypeMismatchException : Exception
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
}
