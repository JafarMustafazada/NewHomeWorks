namespace Delegate.Models;

public class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public override string ToString()
    {
        return this.Name + "_" + this.Surname;
    }
}
