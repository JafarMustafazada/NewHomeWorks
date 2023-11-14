using FileJsonSerialize.Models;

namespace FileJsonSerialize;

internal class Program
{
    static string SInput;
    static void Main()
    {
        void AskId()
        {
            Console.Write("\tCode: ");
            SInput = Console.ReadLine();
        }
        do
        {
            Console.Write("\n0. Toggle auto save (is ");
            if (StudentService.AutoSave) Console.WriteLine("on)");
            else Console.WriteLine(" off)");

            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Edit student");
            Console.WriteLine("4. Clear all");
            Console.WriteLine("5. Read all");
            Console.Write("Action: ");

            switch (Console.ReadLine())
            {
                case "0":
                    if (StudentService.AutoSave) StudentService.AutoSave = false;
                    else
                    {
                        StudentService.AutoSave = true;
                        StudentService.SaveChanges();
                    }
                    break;
                case "1":
                    AskId();

                    Console.Write("\tName: ");
                    string name = Console.ReadLine();

                    Console.Write("\tSurname: ");
                    StudentService.AddStudent(SInput, name, Console.ReadLine());
                    break;
                case "2":
                    AskId();
                    if (StudentService.SelectStudent(SInput))
                    {
                        StudentService.RemoveStudent();
                        Console.WriteLine("Success");
                    }
                    else Console.WriteLine("fail...");
                    break;
                case "3":
                    AskId();
                    if (StudentService.SelectStudent(SInput))
                    {
                        Console.Write("\tNew code (just press enter to skip): ");
                        SInput = Console.ReadLine();

                        Console.Write("\tNew name (just press enter to skip): ");
                        string newname = Console.ReadLine();

                        Console.Write("\tNew surname (just press enter to skip): ");
                        StudentService.EditStudent(SInput, newname, Console.ReadLine());
                    }
                    else Console.WriteLine("fail...");
                    break;
                case "4":
                    StudentService.ClearAll();
                    break;
                case "5":
                    Console.WriteLine(StudentService.ReadAll());
                    break;
            }
        } while (true);
    }
}