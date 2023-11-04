

namespace Task_ListCompanyEmployeeApp.Models;

public abstract class Person
{
    static int _uniqueId = 1;

    public int ID { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public byte Age { get; set; }

    public Person()
    {
        this.ID = Person._uniqueId++;
    }
    public virtual string FullName()
    {
        return "As Person:\n\tFull name: " + Name + "_" + Surname + "\n\tAge: " + Age;
    }

}
