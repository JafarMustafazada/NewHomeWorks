using System.Reflection;
using Task_ExceptionReflection.Exceptions;
using Task_ExceptionReflection.Models;

namespace Task_ExceptionReflection
{
    internal class Program
    {
        static void Main()
        {
            User tests = null;
            UserInput(ref tests);
            Reflection(ref tests);
        }
        static void UserInput(ref User user1)
        {
            user1 = new();
            do
            {
                try
                {
                    Console.Write("\nName: ");
                    user1.Name = Console.ReadLine();

                    Console.Write("Age: ");
                    Byte.TryParse(Console.ReadLine(), out byte age);
                    user1.Age = age;

                    Console.Write("Phone number: ");
                    user1.PhoneNumber = Console.ReadLine();

                    Console.Write("Password: ");
                    user1.Password = Console.ReadLine();
                    break;
                }
                catch (UserExceeptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);

            Console.WriteLine("\n");
        }
        static void Reflection(ref User user1)
        {
            if (user1 == null)
            {
                user1 = new User()
                {
                    Name = "All Mighty Jafar",
                    Age = 19,
                    Password = "Password123",
                    PhoneNumber = "0553334702"
                };
            }

            MemberInfo[] members = typeof(User).GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

            foreach (var item in members)
            {
                Console.Write(item + " -> " + item.MemberType);

                if (item is MethodInfo method && method.IsStatic)
                {
                    method.Invoke(null, new object[] { 33 });
                }
                else if (item is FieldInfo field)
                {
                    if (field.FieldType + "" == "System.String")
                    {
                        field.SetValue(user1, "HaHaHa, hacked");
                    }

                    Console.Write(" --------------> " + field.GetValue(user1));
                }
                else if (item is PropertyInfo property)
                {
                    Console.Write(" --------------> " + property.SetMethod);
                }

                Console.WriteLine();
            }
        }
    }
}