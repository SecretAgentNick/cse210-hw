using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWeclome();
        string nameUser = PromptUserName();
        int favNum = PromptUserNumber();
        int favNumSqr = SquareNumber(favNum);
        DisplayResult(nameUser , favNumSqr);
    }
    static void DisplayWeclome()
    {
        Console.WriteLine("WELCOME TO THIS PROGRAM!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string favoriteNumber = Console.ReadLine();
        return int.Parse(favoriteNumber);
    }
    static int SquareNumber(int number)
    {
        double sqrNum = Math.Pow((number), 2);
        return Convert.ToInt32(sqrNum);
    }
    static void DisplayResult(string name, int sqrFave)
    {
        Console.WriteLine($"{name}, the square root of your number is {sqrFave}");
    }
}