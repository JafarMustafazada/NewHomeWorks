using Delegate.Models;

namespace Delegate;

internal class Program
{
    static void Main(string[] args)
    {   
        List<Exam> exams = new List<Exam>();
        Exam exam1;
        Student student1;
        do
        {
            Console.WriteLine("\n\n1. Create exam");
            Console.WriteLine("2. Show >50 point ones");
            Console.WriteLine("3. Show what is within week");
            Console.WriteLine("4. Show which took more than hour");
            Console.Write("Your action: ");
        
            switch (Console.ReadLine())
            {
                case "1":
                    student1 = new Student();
                    Console.Write("Name of student: ");
                    student1.Name = Console.ReadLine();

                    Console.Write("Surname of student: ");
                    student1.Surname = Console.ReadLine();

                    exam1 = new Exam() { Student = student1 };
                    Console.Write("Subject of exam: ");
                    exam1.Subject = Console.ReadLine();

                    Console.Write("Got thismany points: ");
                    Byte.TryParse(Console.ReadLine(), out byte points);
                    exam1.Points = points;

                    Console.Write("Exam took this many seconds: ");
                    Double.TryParse(Console.ReadLine(), out double seconds);
                    exam1.StartDate = DateTime.Now;
                    exam1.EndDate = DateTime.Now.AddSeconds(seconds);

                    exams.Add(exam1);
                    break;
                case "2":
                    exams.SearchAll(Exam.Methods[(int)Exam.Method.is50PlusPoints]).ForEach(x => Console.WriteLine(x));
                    break;
                case "3":
                    exams.SearchAll(Exam.Methods[(int)Exam.Method.isWithinWeek]).ForEach(x => Console.WriteLine(x));
                    break;
                case "4":
                    exams.SearchAll(Exam.Methods[(int)Exam.Method.isLongerThanHour]).ForEach(x => Console.WriteLine(x));
                    break;
                default:
                    Console.WriteLine("You sure want to leave?(0):");
                    if (Console.ReadLine() == "0") return;
                    break;
            }
        } while (true);

    }
}