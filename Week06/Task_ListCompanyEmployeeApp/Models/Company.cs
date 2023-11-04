

using Task_ListCompanyEmployeeApp.Exceptions;

namespace Task_ListCompanyEmployeeApp.Models;

public class Company
{
    List<Employee> _employees;

    public string Name { get; set; }

    public Company(string name = "Enderg Fun Games")
    {
        Name = name;
        this._employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        this._employees.Add(employee);
    }
    public Employee GetEmployee(int id)
    {
        foreach (Employee emp in this._employees)
        {
            if (emp.ID == id) return emp;
        }
        throw new EmployeeExceptions(EmployeeExceptions.NotFounded);
    }
    public List<Employee> GetEmployees()
    {
        return this._employees;
    }
    public void UpdateEmployee(Employee employee)
    {
        this.GetEmployee(employee.ID);
        Console.WriteLine("1. Update Name");
        Console.WriteLine("2. Update Gender");
        Console.WriteLine("3. Update Salary");
        Console.WriteLine("4. Update Position");
        Console.Write("Your action: ");
        int IInput;

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("New name: ");
                employee.Name = Console.ReadLine();
                break;
            case "2":
                Console.Write("New gender(1/male,2/female): ");
                Gender.TryParse(Console.ReadLine(), out Gender gender);
                if (gender == Gender.male || gender == Gender.female) employee.Gender = gender;
                break;
            case "3":
                Console.Write("New Salary: ");
                decimal.TryParse(Console.ReadLine(), out decimal DInput);
                employee.Salary = DInput;
                break;
            case "4":
                Console.Write("New position: ");
                employee.Position = Console.ReadLine();
                break;
            default:
                return;
        }
    }
    public void RemoveEmployee(Employee employee)
    {
        this._employees.Remove(this.GetEmployee(employee.ID));
    }
}