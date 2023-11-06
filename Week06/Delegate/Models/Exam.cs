namespace Delegate.Models;

public class Exam
{
    public Student Student { get; set; }
    public string Subject { get; set; }
    public byte Points { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    static bool is50PlusPoints(Exam exam) => exam.Points > 50;
    static bool isWithinWeek(Exam exam) => DateTime.Now.Subtract(exam.StartDate).TotalDays < 7;
    static bool isLongerThanHour(Exam exam) => exam.EndDate.Subtract(exam.StartDate).TotalHours > 1;
    public enum Method
    {
        is50PlusPoints,
        isWithinWeek,
        isLongerThanHour
    }
    public static Predicate<Exam>[] Methods = { is50PlusPoints, isWithinWeek, isLongerThanHour };


    public override string ToString()
    {
        return this.Student.ToString() + " at " + this.Subject + " passed exam with " + this.Points
             + " points in " + (long)this.EndDate.Subtract(this.StartDate).TotalSeconds + " seconds";
    }
}

public static class ExamListExtensions
{
    public static List<Exam> SearchAll(this List<Exam> exams, Predicate<Exam> match)
    {
        return exams.FindAll(match);
    }
}