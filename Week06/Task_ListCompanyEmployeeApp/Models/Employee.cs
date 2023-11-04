

namespace Task_ListCompanyEmployeeApp.Models;

public enum Gender
{
    unknown,
    male,
    female
}
public class Employee : Person
{
    public Gender Gender { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }

    public override string FullName()
    {
        return base.FullName() + "\nAs employee:\n\tGender: " + Gender
            + "\n\tPosition: " + Position + "\n\tSalary: " + Salary;
    }
}
