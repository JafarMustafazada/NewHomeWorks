using Task_Generics.Models;

namespace Task_Generics;

internal class Program
{
    static void Main(string[] args)
    {
        EndergMadeList<int> array1 = new EndergMadeList<int>(new int[] { 0, -10, -4, -9 }, -4);

        Console.WriteLine("Capacity: " + array1.Capacity);
        for (int c = 0; c < 4; c++)
        {
            array1[c] = -c;
            array1.Add(c * c);
            Console.WriteLine("Size: " + array1.RealSize);
        }

        Console.WriteLine("\nSuccsess of remove is... " + array1.Remove(array1.IndexOf(-1), default));
        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write(array1[i] + ", ");
        }

        Console.WriteLine("\n\nSuccsess of remove is... " + array1.Remove(-3));
        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write(array1[i] + ", ");
        }

        Console.WriteLine("\n\nIndex of last 0 is: " + array1.LastIndexOf(0));

        Console.WriteLine("\nThis is how reverse would look like: ");
        foreach (var item in array1.Reverse())
        {
            Console.Write(item + ", ");
        }

        array1.Clear();
        Console.WriteLine("\n\nsize after clear: " + array1.RealSize + "; as well as length: " + array1.Length);

        if (!array1.Contains(0))
        {
            Console.WriteLine("\nBoom Shakalaka");
            array1[0] = 0;
        }
    }
}