namespace Core1.Exceptions;

public class UsernameExistException : UserExceptions
{
    public UsernameExistException(string msg = "Username is already registered") : base(msg) { }
}
