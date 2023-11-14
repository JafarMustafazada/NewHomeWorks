using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace FileJsonSerialize.Models;

internal class Student
{
    const string CharSet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+-";

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Code { get; set; }

    public void UpdateCode()
    {
        Random rnd = new Random();
        int length = 9;
        //byte[] bytes = new byte[length];
        //rnd.NextBytes(bytes);
        //this.Code = System.Text.Encoding.Default.GetString(bytes);
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = Student.CharSet[rnd.Next(Student.CharSet.Length)];
        }

        this.Code = new string(chars) + "_" + this.Code;
    }
}

static class StudentService
{
    static List<Student> _students = new List<Student>();
    static Student _student;
    static string _fRoot;

    public static bool AutoSave { get; set; } = true;

    static StudentService()
    {
        StudentService._fRoot = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(StudentService._fRoot)) Directory.CreateDirectory(StudentService._fRoot);

        StudentService._fRoot = Path.Combine(StudentService._fRoot, "jsonData.json");
        if (!File.Exists(StudentService._fRoot))
        {
            //File.Create(StudentService._fRoot);
            // File.Create also create stream in file and dont close it which create problems.
            using (StreamWriter sw = new StreamWriter(StudentService._fRoot)) sw.Close();
            
            return;
        }

        using(StreamReader sr = new StreamReader(StudentService._fRoot))
        {
            //StudentService._students = JArray.Parse(sr.ReadToEnd()).Select(s => new Student
            //{
            //    Name = (string)s["Name"],
            //    Surname = (string)s["Surname"],
            //    Code = (string)s["Code"],
            //}).ToList();

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(sr.ReadToEnd());
            if (students != null) StudentService._students = students;

            sr.Close();
        }
    }

    public static string ReadAll()
    {
        string result = "";
        for (int i = 0; i < StudentService._students.Count; i++)
        {
            result += "\nCode: " + StudentService._students[i].Code;
            result += "\n\tName: " + StudentService._students[i].Name;
            result += "\n\tSurname: " + StudentService._students[i].Surname;
        }

        return result;
    }

    public static void AddStudent(string code, string name, string surname)
    {
        StudentService._student = new Student
        { 
            Name = name,
            Surname = surname,
            Code = code
        };
        StudentService._student.UpdateCode();
        StudentService._students.Add(StudentService._student);

        if (StudentService.AutoSave) StudentService.SaveChanges();
    }

    public static bool SelectStudent(string code)
    {
        try
        {
            StudentService._student = StudentService._students.SingleOrDefault(s => s.Code == code);
        }
        catch (Exception)
        {
            Console.WriteLine("ONE IN 18,014,398,509,481,984 CHANCE (2,251,799 times more than humans)");
            StudentService._students.Find(s => s.Code == code).UpdateCode();
            return false;
        }
        return (StudentService._student != null);
    }

    public static void RemoveStudent()
    {
        StudentService._students.Remove(StudentService._student);

        if (StudentService.AutoSave) StudentService.SaveChanges();
    }

    public static void ClearAll()
    {
        StudentService._students.Clear();
        if (StudentService.AutoSave) StudentService.SaveChanges();
    }

    public static void EditStudent(string newcode = "", string name = "", string surname = "")
    {
        if (!String.IsNullOrWhiteSpace(newcode))
        {
            StudentService._student.Code = newcode;
            StudentService._student.UpdateCode();
        }
        if (!String.IsNullOrWhiteSpace(name)) StudentService._student.Name = name;
        if (!String.IsNullOrWhiteSpace(surname)) StudentService._student.Surname = surname;

        if (StudentService.AutoSave) StudentService.SaveChanges();
    }

    public static void SaveChanges()
    {
        using (StreamWriter sw = new StreamWriter(StudentService._fRoot))
        {
            //JArray.FromObject(StudentService._students)
            sw.Write(JsonConvert.SerializeObject(StudentService._students));

            sw.Close();
        }
    }
}