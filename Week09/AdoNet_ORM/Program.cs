using Core1.Exceptions;
using Core1.Models;
using Core1.Services;

namespace AdoNet_ORM;

internal class Program
{
    static string SInput;
    static int IInput;
    static int Login()
    {
        Console.WriteLine("\n1. Register");
        Console.WriteLine("2. Login");
        Console.Write("Action: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("\tName: ");
                string name = Console.ReadLine();

                Console.Write("\tSurname: ");
                string surname = Console.ReadLine();

                Console.Write("\tUsername: ");
                SInput = Console.ReadLine();

                Console.Write("\tPassword: ");
                UserService.Register(new Users()
                {
                    Password = Console.ReadLine(),
                    Username = SInput,
                    Name = name,
                    Surname = surname
                });
                return 0;
            case "2":
                Console.Write("\tUsername: ");
                SInput = Console.ReadLine();

                Console.Write("\tPassword: ");
                if (UserService.Login(SInput, Console.ReadLine())) return 1;
                return -1;
            default:
                return 0;
        }
    }
    static void Menu()
    {
        Console.WriteLine("\n1. Get all blogs");
        Console.WriteLine("2. Get blog by id");
        Console.WriteLine("3. Create user blog");
        Console.WriteLine("4. Edit user blog by id");
        Console.WriteLine("5. Delete user blog");

        switch (Console.ReadLine())
        {
            case "1":
                BlogService.GetAll().ForEach(x => Console.WriteLine("\t" + x.Id + "_" + x.Title + "_" + x.Describtion));
                break;
            case "2":
                Console.Write("ID: ");
                Int32.TryParse(Console.ReadLine(), out IInput);

                Blogs blog = BlogService.GetById(IInput);
                Console.WriteLine("\t" +blog.Id + "_" + blog.Title + "_" + blog.Describtion);
                break;
            case "3":
                Console.Write("Title: ");
                SInput = Console.ReadLine();

                Console.Write("Describtion: ");
                UserService.Create(new Blogs 
                {
                    Title = SInput,
                    Describtion = Console.ReadLine()
                });
                break; 
            case "4":
                Console.Write("ID: ");
                Int32.TryParse(Console.ReadLine(), out IInput);

                Console.Write("Title: ");
                SInput = Console.ReadLine();

                Console.Write("Describtion: ");
                UserService.Edit(IInput, new Blogs
                {
                    Title = SInput,
                    Describtion = Console.ReadLine()
                });
                break;
            case "5":
                Console.Write("ID: ");
                Int32.TryParse(Console.ReadLine(), out IInput);

                UserService.Delete(IInput);
                break;
        }
    }
    static void Main(string[] args)
    {
        do
        {
            try
            {
                while (!UserService.IsLogin())
                {
                    int result = Login();
                    if (result < 0) Console.WriteLine("Fail to login.");
                    else if (result > 0) Console.WriteLine("\nWelcome " + UserService.Welcome());
                }
                Menu();
            }
            catch (ServiceEceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (true);
    }
}
