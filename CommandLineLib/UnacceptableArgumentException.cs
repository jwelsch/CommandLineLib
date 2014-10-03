using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineLib
{
   /// <summary>
   /// Thrown when a command line argument does not have an accepted value.
   /// </summary>
   [Serializable]
   public class UnacceptableArgumentException : Exception
   {
      public object UnacceptableValue
      {
         get;
         private set;
      }

      /// <summary>
      /// Constructs an object of type UnacceptableArgumentException.
      /// </summary>
      public UnacceptableArgumentException()
      {
      }

      /// <summary>
      /// Constructs an object of type UnacceptableArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      public UnacceptableArgumentException( string message, object unacceptableValue )
         : this( message, unacceptableValue, null )
      {
      }

      /// <summary>
      /// Constructs an object of type UnacceptableArgumentException.
      /// </summary>
      /// <param name="message">The message associated with the exception.</param>
      /// <param name="innerException">Another exception associated with the UnacceptableArgumentException.</param>
      public UnacceptableArgumentException( string message, object unacceptableValue, Exception innerException )
         : base( message, innerException )
      {
         this.UnacceptableValue = unacceptableValue;
      }

      /// <summary>
      /// Constructs a UnacceptableArgumentException object.
      /// </summary>
      /// <param name="info">The serialization information.</param>
      /// <param name="context">The streaming context.</param>
      protected UnacceptableArgumentException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
