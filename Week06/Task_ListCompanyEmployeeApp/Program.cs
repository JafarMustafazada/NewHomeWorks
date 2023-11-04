

using Task_ListCompanyEmployeeApp.Exceptions;
using Task_ListCompanyEmployeeApp.Models;

namespace Task_ListCompanyEmployeeApp;

internal class Program
{
    static void Main()
    {
        Company company1 = new Company();
        Employee employee1;
        int IInput;
        do
        {
            Console.WriteLine("\n" + company1.Name);
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Get employee by id");
            Console.WriteLine("3. Get all employees");
            Console.WriteLine("4. Update employee details");
            Console.WriteLine("5. Delete employee by id");
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
                        Gender.TryParse(Console.ReadLine().ToLower(), out Gender gender);
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
                        employee1 = company1.GetEmployee(IInput);

                        Console.WriteLine(employee1.FullName());
                        break;
                    case "3":
                        foreach (Employee item in company1.GetEmployees())
                        {
                            Console.WriteLine("\tID: " + item.ID + ", Name: " + item.Name);
                        }
                        break;
                    case "4":
                        Console.Write("ID: ");
                        Int32.TryParse(Console.ReadLine(), out IInput);
                        company1.UpdateEmployee(company1.GetEmployee(IInput));
                        break;
                    case "5":
                        Console.Write("ID: ");
                        Int32.TryParse(Console.ReadLine(), out IInput);
                        company1.RemoveEmployee(company1.GetEmployee(IInput));
                        break;
                    default:
                        break;
                }
            }
            catch (EmployeeExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (true);
    }
}