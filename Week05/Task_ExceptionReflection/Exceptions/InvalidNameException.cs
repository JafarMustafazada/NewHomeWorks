using System.Runtime.Serialization;

namespace Task_ExceptionReflection.Exceptions
{
    internal class InvalidNameException : UserExceeptions
    {
        public InvalidNameException() { }

        public InvalidNameException(string? message) : base(message) { }
    }
}