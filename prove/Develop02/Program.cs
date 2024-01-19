using System;
using System.IO.Enumeration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = new Journal();
        Prompt promptList = new Prompt();
        Random rnd = new Random();
        Int32 lengthofPrompt = promptList._Prompts.Count();
        System.Console.WriteLine("Welcome to Journaling Via Code");
        while (true)
        {   
            System.Console.WriteLine("What would you like to do today?");
            System.Console.WriteLine("1. Write \n2. Display \n3. Load \n4. Save \n5. Quit Program");
            string userChoice = Console.ReadLine();


            if (userChoice == "1") //Write 
            {
                int rndNumber = rnd.Next(0, lengthofPrompt);
                System.Console.WriteLine(promptList._Prompts[rndNumber]);
                journal1._contents = Console.ReadLine();
                journal1._completePrompts.Add($"Date: {DateTime.Now} \nPrompt: {promptList._Prompts[rndNumber]} \nResponse: {journal1._contents} \n");
            }


            else if (userChoice == "2") //Display
            {  
                if (journal1._contents != string.Empty)
                {
                    foreach (string response in journal1._completePrompts)
                    {
                        System.Console.WriteLine(response);
                    }
                }
                else
                {
                    System.Console.WriteLine("ERROR: NO FILE FOUND!");
                }
            }


            else if (userChoice == "3") //Load
            {
                System.Console.WriteLine("Enter a Filename to load: ");
                string fileLoad = Console.ReadLine();
                if (File.Exists(fileLoad))
                {
                    System.Console.WriteLine("FILE LOADED");
                    journal1._fileName = fileLoad;
                    journal1._contents = File.ReadAllText(fileLoad);
                    journal1._completePrompts.Add(journal1._contents);
                    System.Console.WriteLine($"Your last time writing in your journal was {File.GetLastWriteTime(fileLoad)}."); //This reminds the user last time they wrote in thier journal. Hopefully it will guilt them into writting more if the date is far enough away.
                }
                else
                {
                    System.Console.WriteLine("ERROR: NO FILE FOUND!");
                }
            }


            else if (userChoice == "4") //Save
            {
                System.Console.WriteLine("Enter a Filename or enter nothing for default filename (DailyJournal.txt): ");
                string userJournal = Console.ReadLine();
                if (userJournal != "")
                {
                    journal1._fileName = userJournal;
                }
                foreach (string completeResponse in journal1._completePrompts) //Checks before every write if the location exists
                {
                    if (!File.Exists(journal1._fileName))
                    {
                        File.WriteAllText(journal1._fileName, completeResponse);
                    }
                    else
                    {
                        File.AppendAllText(journal1._fileName, completeResponse);
                    }

                }
                System.Console.WriteLine("FINISHED SAVING JOURNAL");
            }


            else if (userChoice == "5") //Exit Program
            {
                break;
            }


            else if (userChoice == "6") //Read Prompts Secret Hidden Option
            {
                System.Console.WriteLine("Secret Option Found. Here are all of the Prompts!");
                foreach (string prompt in promptList._Prompts)
                {
                    System.Console.WriteLine($"{prompt}\n");
                }
            }

            else //Failsafe incase user enters the wrong values
            {
                System.Console.WriteLine("INVALID RESPONSE DETECTED. PLEASE TRY AGAIN.");
            }
        }
    }
}