using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<double> Numbers = new List<double>();
        while (true)
        {
            Console.Write("Enter Number: ");
            userInput = Console.ReadLine();
            if (userInput == "0")
            {
                break;
            }
            else
            {
                Numbers.Add(int.Parse(userInput));
            }
        }
        //Computes the Sum, Average, and finding the largest number.
        double sumNum = Numbers.Sum();
        double avgNum = Numbers.Average();
        double larNum = Numbers.Max();
        double smalNum = Numbers.Min();
        Numbers.Sort();
        //Displays the Sum, Average, and largest number
        Console.WriteLine($"The sum is: {sumNum}");
        Console.WriteLine($"The Average is: {avgNum}");
        Console.WriteLine($"The Largest Number is: {larNum}");
        Console.WriteLine($"The Smallest Number is: {smalNum}");
        Console.WriteLine("Here is your sorted number list:");
        foreach (int i in Numbers)
        {
            Console.WriteLine(i);
        }
    }
}