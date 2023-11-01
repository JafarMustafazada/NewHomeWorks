namespace Task_IndexerExtension;

internal class Program
{
    static void Main(string[] args)
    {
        /*
        Console.WriteLine("Tests 1.");
        Console.WriteLine((-3).IsPrime());
        Console.WriteLine(3.IsPrime());
        Console.WriteLine(7.IsPrime());
        Console.WriteLine(25.IsPrime());
        Console.WriteLine(24.IsPrime());
        Console.WriteLine(16.IsPowOfTwo());
        Console.WriteLine(17.IsPowOfTwo());
        */
        Gallery JafarsGarage = new Gallery();
        JafarsGarage.Cars = new Car[10];
        JafarsGarage.Cars[0] = new Car() { Name = "EndergTech327", Color = "Turquoise Tranquility", ProducedYear = "2004" };
        JafarsGarage.Cars[1] = new Car() { Name = "EndergTech007", Color = "Indigo Illusion", ProducedYear = "2004" };
        JafarsGarage.Cars[2] = new Car() { Name = "Endergs Pride", Color = "Crimson Royale", ProducedYear = "2005" };
        JafarsGarage.Cars[3] = new Car() { Name = "EndergTech666", Color = "Champagne Blush", ProducedYear = "2004" };
        Console.WriteLine(JafarsGarage[0]);
    }
}