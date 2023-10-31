using Task_StaticExtension.Models;

namespace Task_StaticExtension;

internal class Program
{
    static void Main(string[] args)
    {
        string NameInput;
        Student student = null;
        do
        {
            //Console.WriteLine("'BestPractise' example: Narmin, Zanudova, 69, A327");
            Console.Write("\nTry creating student till all fields is right.\nName: ");
            NameInput = Console.ReadLine();

            Console.Write("Surname: ");
            NameInput += " " + Console.ReadLine();

            Console.Write("Age: "); 
            Byte.TryParse(Console.ReadLine(), out byte age);

            Console.Write("Group code: ");
            student = new Student(NameInput, Console.ReadLine(), age);

        } while (student.FullName == "_" || student.GroupNo == "_" || student.Age == 0);

        Console.WriteLine("\nsuccess:");
        Console.WriteLine("Full name: " + student.FullName);
        Console.WriteLine("Age: " + student.Age);
        Console.WriteLine("Group code: " + student.GroupNo);
    }
}