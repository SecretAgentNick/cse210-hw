using System;

class Program
{
    static void Main(string[] args)
    {
        Reference Omni1 = new Reference();
        Word OmniText = new Word();
        Scripture scripture1 = new Scripture(Omni1, OmniText);
        
        while (true)
        {
            string beforeReplacement = scripture1.GetDisplayText();
            System.Console.WriteLine(scripture1.GetDisplayText());
            Console.WriteLine("Press Enter or type 'quit' to finish:");
            string userInput = Console.ReadLine();
            scripture1.HideRandomWords(1);
            if (scripture1.GetDisplayText() == beforeReplacement)
            {
                break;
            }
            if (userInput.ToLower() == "quit")
            {
                break;
            }
            Console.Clear();
        }


    }
}