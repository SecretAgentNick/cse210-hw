using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Josh Guy", "Addition");
        System.Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Not Josh", "Subtractions", "7.3", "8-19");
        System.Console.WriteLine(a2.GetSummary());
        System.Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("This is Josh", "Comic Books", "Who isn't batman");
        System.Console.WriteLine(a3.GetSummary());
        System.Console.WriteLine(a3.GetWritingInformation());
    }
}