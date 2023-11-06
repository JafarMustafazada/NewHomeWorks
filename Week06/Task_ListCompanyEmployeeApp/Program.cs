

using Task_ListCompanyEmployeeApp.Exceptions;
using Task_ListCompanyEmployeeApp.Models;

namespace Task_ListCompanyEmployeeApp;

internal class Program
{
    static bool IsMale(Employee emp) => emp.Gender == Gender.male;
    static bool IsFemale(Employee emp) => !IsMale(emp);
    static bool IsLegalAge(Employee emp) => emp.Age >= 18;
    static bool IsAdmin(Employee emp) => emp.Position == "Admin";

    static void Main()
    {
        Func<Employee, bool>[] methods = { IsMale, IsFemale, IsLegalAge, IsAdmin };
        Company company1 = new Company();
        company1.AddEmployee(new Employee
        {
            Name = "Jafar",
            Surname="Zorzade",
            Salary = 99999999,
            Age = 19,
            Gender = Gender.male,
            Position = "Admin"
        });
        company1.AddEmployee(new Employee
        {
            Name = "Ulvi",
            Surname = "Zorzade",
            Salary = 9,
            Age = 17,
            Gender = Gender.female,
            Position = "guest"
        });
        company1.AddEmployee(new Employee
        {
            Name = "Narmin",
            Surname = "Zorzade",
            Salary = 99999999,
            Age = 24,
            Gender = Gender.female,
            Position = "Admin"
        });
        Employee employee1;
        int IInput;
        int action = 0;
        do
        {
            Console.WriteLine("\n\n" + company1.Name);
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Get employee by id");
            Console.WriteLine("3. Get all employees");
            Console.WriteLine("4. Update employee details");
            Console.WriteLine("5. Delete employee by id");
            Console.WriteLine("6. Custom search first result");
            Console.WriteLine("7. Custom search results");
            Console.WriteLine("8. Custom delete");
            Console.Write("Your Action: ");
            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        employee1 = new Employee();

                        Console.Write("Name: ");
                        employee1.Name = Console.ReadLine();

                        Console.Write("Surname: ");
                        employee1.Surname = Console.ReadLine();

                        Console.Write("Gender(1/male,2/female): ");
                        Gender.TryParse(Console.ReadLine()?.ToLower(), out Gender gender);
                        if (gender == Gender.male || gender == Gender.female) employee1.Gender = gender;

                        Console.Write("Age: ");
                        Byte.TryParse(Console.ReadLine(), out byte BInput);
                        employee1.Age = BInput;

                        Console.Write("Position: ");
                        employee1.Position = Console.ReadLine();

                        Console.Write("Salary: ");
                        decimal.TryParse(Console.ReadLine(), out decimal DInput);
                        employee1.Salary = DInput;

                        company1.AddEmployee(employee1);
                        Console.WriteLine("Employee added.");
                        break;
                    case "2":
                        Console.Write("ID of employee: ");
                        Int32.TryParse(Console.ReadLine(), out IInput);
                        employee1 = company1.GetEmployeeById(IInput);

                        Console.WriteLine(employee1.FullName());
                        break;
                    case "3":
                        company1.GetEmployees().ForEach(item => Console.WriteLine("\tID: " + item.ID + ", Name: " + item.Name));
                        break;
                    case "4":
                        Console.Write("ID: ");
                        Int32.TryParse(Console.ReadLine(), out IInput);
                        company1.UpdateEmployee(company1.GetEmployeeById(IInput));
                        break;
                    case "5":
                        Console.Write("ID: ");
                        Int32.TryParse(Console.ReadLine(), out IInput);
                        company1.RemoveEmployee(company1.GetEmployeeById(IInput));
                        break;
                    case "6":
                        action = 6;
                        break;
                    case "7":
                        action = 7;
                        break;
                    case "8":
                        action = 8;
                        break;
                    default:
                        break;
                }
                if (action > 0)
                {
                    Console.WriteLine("0. Is male");
                    Console.WriteLine("1. Is female");
                    Console.WriteLine("2. Is legal age");
                    Console.WriteLine("3. Is admin");
                    Console.Write("Choose custom method: ");
                    Int32.TryParse(Console.ReadLine(), out IInput);

                    if(IInput >= 0 && IInput < methods.Length)
                    {
                        switch (action)
                        {
                            case 6:
                                Console.WriteLine(company1.GetFirstEmployee(methods[IInput]).FullName());
                                break;
                            case 7:
                                company1.GetAllEmployees(methods[IInput]).ForEach(item => Console.WriteLine("\tID: " + item.ID + ", Name: " + item.Name));
                                break;
                            case 8:
                                Console.WriteLine("Amount of deleted values: " + company1.RemoveAll(methods[IInput]));
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                    }
                    action = 0;
                }
            }
            catch (EmployeeExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (true);
    }
    //end of main
}