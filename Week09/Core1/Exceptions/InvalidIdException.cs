namespace Core1.Exceptions;

public class InvalidIdException : UserExceptions
{
    public InvalidIdException(string message = "Id cannot be less than 1.") : base(message) { }
}
