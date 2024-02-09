using System.Diagnostics.Metrics;

public class Reflection : Activity
{
    private Random _rndNumber = new Random();
    private List<int> _rndList = new List<int>();
    private List<string> _promptList = new List<string>
    {
    "Think of a time when you stood up for someone else."
    ,"Think of a time when you did something really difficult."
    ,"Think of a time when you helped someone in need."
    ,"Think of a time when you did something truly selfless."
    };
    private List<string> _respsonseList = new List<string>
    {
        
    "Why was this experience meaningful to you?"
    ,"Have you ever done anything like this before?"
    ,"How did you get started?"
    ,"How did you feel when it was complete?"
    ,"What made this time different than other times when you were not as successful?"
    ,"What is your favorite thing about this experience?"
    ,"What could you learn from this experience that applies to other situations?"
    ,"What did you learn about yourself through this experience?"
    ,"How can you keep this experience in mind in the future?"

    };
    public Reflection(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Prompt(int seconds)
    {
        int promptNum = _rndNumber.Next(0,_promptList.Count-1);
        int counter = 0;
        Console.WriteLine($"{_promptList[promptNum]}\nPress any key to continue:");
        Console.ReadKey();
        while (true)
        {
            if (_respsonseList.Count == _rndList.Count)
            {
                Console.WriteLine(_respsonseList[_rndList[counter]]);
                ShowSpinner(seconds);
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < _respsonseList.Count;i++) //CREATES A RANDOM LIST FROM THE LENGTH OF THE ORINAL. PREVENTS REPEATS.
                {
                    _rndList.Add(i);
                }   
                _rndList = _rndList.OrderBy(x=> Random.Shared.Next()).ToList();
            }
            counter += 1;
            if (counter > 2)
            {;
                break;
            }
        }
    }
}