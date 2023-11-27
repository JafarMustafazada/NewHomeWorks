namespace Core1.Exceptions;

public class NoSearchResultException : ServiceEceptions
{
    public NoSearchResultException(string msg = "Search result is empty") : base(msg) { }
}
