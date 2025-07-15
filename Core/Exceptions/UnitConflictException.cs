
namespace eshift_management.Core.Exceptions
{
    /// <summary>
    /// Represents an error that occurs when a transport unit has a scheduling conflict.
    /// This custom exception is used to communicate a specific business rule violation
    /// from the service layer to the UI, allowing the UI to handle it gracefully
    /// (e.g., by showing a confirmation dialog).
    /// </summary>
    public class UnitConflictException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitConflictException"/> class.
        /// </summary>
        public UnitConflictException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitConflictException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnitConflictException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitConflictException"/> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public UnitConflictException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
