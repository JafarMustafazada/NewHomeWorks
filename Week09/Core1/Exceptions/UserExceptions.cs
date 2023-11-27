namespace Core1.Exceptions;

public abstract class UserExceptions : ServiceEceptions
{
    public UserExceptions(string msg = "Unknown User Exception") : base(msg) { }
}
