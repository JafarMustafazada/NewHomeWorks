using System.Runtime.Serialization;

namespace Task_ExceptionReflection.Exceptions
{
    [Serializable]
    internal class InvalidPasswordException : UserExceeptions
    {
        public InvalidPasswordException() { }

        public InvalidPasswordException(string? message) : base(message) { }
    }
}