using System.Runtime.Serialization;

namespace Task_ExceptionReflection.Exceptions
{
    [Serializable]
    internal class InvalidPhoneNumberException : UserExceeptions
    {
        public InvalidPhoneNumberException() { }

        public InvalidPhoneNumberException(string? message) : base(message) { }
    }
}