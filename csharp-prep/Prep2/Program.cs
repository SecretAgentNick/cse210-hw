using System;

class Program
{
    static void Main(string[] args)
    {
        string grade = null;
        Console.WriteLine("What is your Grade Percentage? ");
        string userInput = Console.ReadLine();
        int testScore = int.Parse(userInput);
        if (testScore >= 90)
        {
            if (testScore > 93)
            {
                grade = "A";
            }
            else
            {
                grade = "A-";
            }
        }
        else if (testScore >= 80)
        {
            if (testScore >= 87)
            {
                grade = "B+";
            }
            else if (testScore > 83)
            {
                grade = "B";
            }
            else
            {
                grade = "B-";
            }
        }
        else if (testScore >= 70)
        {
            if (testScore >= 77)
            {
                grade = "C+";
            }
            else if (testScore > 73)
            {
                grade = "C";
            }
            else
            {
                grade = "C-";
            }
        }
        else if (testScore >= 60)
        {
            if (testScore >= 67)
            {
                grade = "D+";
            }
            else if (testScore > 63)
            {
                grade = "D";
            }
            else
            {
                grade = "D-";
            }
        }
        else if (testScore >= 0)
        {
            grade = "F";
        }
        else
        {
            Console.WriteLine("Since I do not recognize your answer, I am going to assume it is an F");
        }

        Console.WriteLine($"Your grade is {grade}.");
        if (testScore >= 70)
        {
            Console.WriteLine("Congrats on passsing this nonexistant clase :D ");
        }
        else
        {
            Console.WriteLine("Try to pass next time, rerun the program and enter a passing grade.");
        }
    }
}