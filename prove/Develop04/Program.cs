using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        Breathing b1 = new Breathing("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 0);
        Reflection r1 = new Reflection("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0);
        Listing l1 = new Listing("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0);

        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity\n2. Start Reflecting Activity\n3. Start Listing Activity\n4. Quit");
            userInput = Console.ReadLine();
            if (userInput == "1") //Breathing
            {
                b1.DisplayStartingMessage();
                b1.InandOut(b1.SetDuration());
                b1.DisplayEndingMessage();
            }
            else if (userInput == "2") //Reflecting There are no repeating prompts due to code in the reflection.cs
            {
                r1.DisplayStartingMessage();
                r1.Prompt(r1.SetDuration());
                r1.DisplayEndingMessage();
            }
            else if (userInput == "3") //Listing
            {
                l1.DisplayStartingMessage();
                l1.Prompt(l1.SetDuration());
                l1.DisplayEndingMessage();
            }
            else if (userInput == "4") //Quit
            {
                Console.WriteLine("Have a good day :)");
                break;
            }
            else
            {
                System.Console.WriteLine("UNKNOWN INPUT. PLEASE TRY AGAIN");
            }
            Console.Clear();
        }
    }
}
