using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string userGuess;
        string playAgain;
        while (true)
        {
            int magicNumber = randomGenerator.Next(1,100);
            bool guessCorrect = false;
            int guessNum = 0;
            while (guessCorrect == false)
            {
                Console.WriteLine($"Current Number of Guesses: {guessNum}");
                Console.WriteLine($"My number is {magicNumber}");
                Console.WriteLine("What is your guess?");
                
                userGuess = Console.ReadLine();
                if (int.Parse(userGuess) == magicNumber)
                {
                    Console.WriteLine("\nThat is my magic number!");
                    guessCorrect = true;
                }
                else if (int.Parse(userGuess) > magicNumber)
                {
                    Console.WriteLine("\nLOWER!");
                }
                else if (int.Parse(userGuess) < magicNumber)
                {
                    Console.WriteLine("\nHIGHER!");
                }
                else
                {
                    Console.WriteLine("\nHow did you get here?");
                }
                guessNum += 1;
            }
            Console.WriteLine("\nWould you like to play again? Yes / No");
            playAgain = Console.ReadLine().ToLower();
            if (playAgain == "no")
            {
                Console.WriteLine("Goodbye :)");
                break;
            }
        }

    }
}