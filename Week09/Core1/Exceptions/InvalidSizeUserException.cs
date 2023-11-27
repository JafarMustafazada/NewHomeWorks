namespace Core1.Exceptions;

public class InvalidSizeUserException : UserExceptions
{
    public InvalidSizeUserException(string message = "Must contain one character.") : base(message) { }
}
