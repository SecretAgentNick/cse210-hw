using System.Diagnostics.Metrics;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public int SetDuration()
    {
        while (true)
        {       
            try
            {
                Console.WriteLine($"How long, in seconds, would you like for your session?");
                _duration = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("ERROR Please enter a valid number.");
            }
        }
        ShowSpinner(8);
        return _duration;
    }
    public void DisplayStartingMessage() //Displays a welcome message.
    {
        Console.WriteLine($"Welcome to the {_name} Activity");

        Console.WriteLine(_description);
    }
    public void DisplayEndingMessage() //Displays a ending message
    {
        Console.WriteLine("Well done :)");
        Console.WriteLine($"You've completed a {_name} for {_duration} seconds.");
        Console.WriteLine("Press any key to continue:");
        Console.ReadKey();
    }
    public void ShowSpinner(int seconds)
    {
        string[] loadingBar = {"/", "|", "\\", "-"}; //Made modular so that the spinner can be replaced with other art.
        int iOverflow = 0;
        for (int i = 0; i < seconds; i++)
        {   
            if (i > loadingBar.Length - 1)
            {
                if (iOverflow > loadingBar.Length - 1)
                {
                    iOverflow = 0;
                }
                else
                {
                    Console.Write(loadingBar[iOverflow]);
                    iOverflow += 1;
                }
            }
            else
            {
                Console.Write(loadingBar[i]);
            }
            Thread.Sleep(200);
            Console.Write("\b");
        }
    }
}