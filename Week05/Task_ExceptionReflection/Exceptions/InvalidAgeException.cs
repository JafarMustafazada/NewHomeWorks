using System.Runtime.Serialization;

namespace Task_ExceptionReflection.Exceptions
{
    internal class InvalidAgeException : UserExceeptions
    {
        public InvalidAgeException() { }

        public InvalidAgeException(string? message) : base(message) { }
    }
}