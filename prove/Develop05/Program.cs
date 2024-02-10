using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goal = new GoalManager();
        string userInput;
        while (true)
        {
            goal.DisplayInfo();
            System.Console.WriteLine("Menu Options \n1.Create New Goal \n2.List Goals \n3.Save Goals \n4.Load Goals \n5.Record Event \n6.Quit");
            userInput = Console.ReadLine();
            if (userInput == "1") //Create New Goal
            {
                choiceNewGoal();
            }
            else if (userInput == "2") //List Goals
            { 
                goal.ListGoal();
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else if (userInput == "3") //Save Goals
            {
                System.Console.WriteLine("Please enter a valid file name. \nFor example 'Goals.txt'");
                goal.SaveGoals(Console.ReadLine());
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else if (userInput == "4") //Load Goals
            {
                System.Console.WriteLine("Please enter a valid file name. \nFor example 'Goals.txt'");
                goal.LoadGoals(Console.ReadLine());
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else if (userInput == "5") //Record Event
            {
                goal.RecordEvent(goal.GoalListLength());
            }
            else if (userInput == "6") //Quit
            {
                System.Console.WriteLine("Have a good day :) \nExiting Program");
                break;
            }
            else //Entry Not Found
            {
                System.Console.WriteLine("Unknown input please try again");
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            Console.Clear();
        }
        void choiceNewGoal() //Allows user to choose their own goal.
        {
            string userGoal, userDescription;
            int userPoints, userBonus, userRepeat, userchoice;
            while (true)
            {
                try
                {
                    System.Console.WriteLine("What goal would you like to pursue? \n1.Simple Goal \n2.Eternal Goal \n3.Checklist Goal");
                    userchoice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    System.Console.WriteLine("INVALID RESPONSE. PLEASE TRY AGAIN.");
                }    
            }
            System.Console.WriteLine("What is the name of your goal?");
            userGoal = Console.ReadLine();
            System.Console.WriteLine("What is the description of your goal?");
            userDescription = Console.ReadLine();
            while (true)
            {
                try
                {
                    System.Console.WriteLine("How many points is it worth?");
                    userPoints = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    System.Console.WriteLine("INVALID RESPONSE. PLEASE TRY AGAIN.");
                }
            }
            if (userchoice == 1) //Simple
            {
                goal.CreateSimpleGoal(userGoal, userDescription, userPoints);
            }
            else if (userchoice == 2) //Eternal
            {
                goal.CreateEternalGoal(userGoal, userDescription, userPoints);
            }
            else if (userchoice == 3) //Checklist
            {
                while (true)
                {
                    try
                    {
                        System.Console.WriteLine("How many times will this task need to be completed to receive a bonus?");
                        userRepeat = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("How many points will the bonus be?");
                        userBonus = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        System.Console.WriteLine("INVALID RESPONSE. PLEASE TRY AGAIN.");
                    }
                }
                goal.CreateChecklistGoal(userGoal, userDescription, userPoints, userRepeat, userBonus);
            }
        }
    }
}