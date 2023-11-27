namespace Core1.Exceptions;

public abstract class ServiceEceptions : Exception
{
    public ServiceEceptions(string msg = "Unknown Service Exception") : base(msg) { }
}
