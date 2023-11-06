

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
        CompanyDatabase.CompaniesList.Add(this);
    }

    public void AddEmployee(Employee employee)
    {
        this._employees.Add(employee);
    }
    public Employee GetEmployeeById(int id)
    {
        Employee? emp = this._employees.SingleOrDefault(item => item.ID == id);
        if (emp != null) return emp;
        throw new EmployeeExceptions(EmployeeExceptions.NotFounded);
    }
    public Employee GetFirstEmployee(Func<Employee, bool> match)
    {
        Employee? emp = this._employees.FirstOrDefault(match);
        if (emp != null) return emp;
        throw new EmployeeExceptions(EmployeeExceptions.NotFounded);
    }
    public List<Employee> GetEmployees()
    {
        return this._employees;
    }
    public List<Employee> GetAllEmployees(Func<Employee, bool> match)
    {
        List<Employee> newList = new List<Employee>();
        this._employees.ForEach(item => newList.Add(item));
        if (newList.Count > 0) return newList;
        throw new EmployeeExceptions(EmployeeExceptions.NotFounded);
    }
    public void UpdateEmployee(Employee employee)
    {
        this.GetEmployeeById(employee.ID);
        Console.WriteLine("1. Update Name");
        Console.WriteLine("2. Update Gender");
        Console.WriteLine("3. Update Salary");
        Console.WriteLine("4. Update Position");
        Console.Write("Your action: ");

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
        this._employees.Remove(this.GetEmployeeById(employee.ID));
    }
    public void RemoveAll()
    {
        this._employees.Clear();
    }
    public int RemoveAll(Func<Employee, bool> match)
    {
        return this._employees.RemoveAll(emp => match(emp));
    }
}

public static class CompanyDatabase
{
    static public List<Employee> EmployeesList = new List<Employee>();
    static public List<Company> CompaniesList = new List<Company>();
}