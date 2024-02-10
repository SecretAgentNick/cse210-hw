using System.Diagnostics.Metrics;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }  
    public void DisplayInfo()
    {
        System.Console.WriteLine($"Current Score: {_score}");
    }
    public void ListGoal()
    {
        int counter = 0;
        string complete;
        System.Console.WriteLine("Your Goals Are:");
        foreach (var i in _goals)
        {
            complete = " ";
            counter += 1;
            if (i.IsComplete())
            {
                complete = "*";
            }
            System.Console.WriteLine($"{counter}. [{complete}]{i.GetStringRepresentation()}");
        }
    }
    public void CreateSimpleGoal(string shortName, string description, int points)
    {
        Goal newGoal = new SimpleGoal(shortName, description, points);
        _goals.Add(newGoal);
    }
    public void CreateEternalGoal(string shortName, string description, int points)
    {
        Goal newGoal = new EternalGoal(shortName, description, points);
        _goals.Add(newGoal);      
    }
    public void CreateChecklistGoal(string shortName, string description, int points, int repeat, int bonusPoints)
    {
        Goal newGoal = new ChecklistGoal(shortName, description, points, repeat, bonusPoints);
        _goals.Add(newGoal);        
    }
    public void RecordEvent(int goalIndex)
    {
        try
        {
            int userChoice;
            ListGoal();
            System.Console.WriteLine("Which goal did you complete?");
            userChoice = Convert.ToInt32(Console.ReadLine());
            if (userChoice <= _goals.Count())
            {
                _goals[userChoice-1].RecordEvent();
                _score = _score + _goals[userChoice-1].GetPoints();
            }
        }
        catch
        {
        }

    }   

    public int GoalListLength()
    {
        return _goals.Count();
    }
    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);
            foreach (var i in _goals)
            {
                writer.WriteLine($"{i.GetType().Name},{i.GetShortName()},{i.GetDescription()},{i.GetPoints()},{i.IsComplete()}");
            }
        }
        Console.WriteLine($"Goals Saved to {fileName}.");
    }
    public void LoadGoals(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string readLine;
            List<string> GoalListLoader = new List<string>();
            _score = Convert.ToInt32(reader.ReadLine());
            while ((readLine = reader.ReadLine()) != null)
            {
                GoalListLoader = new List<string>(readLine.Split(","));
                if (GoalListLoader[0] == "SimpleGoal")
                {
                    CreateSimpleGoal(GoalListLoader[1],GoalListLoader[2],Convert.ToInt32(GoalListLoader[3]));
                }
                else if (GoalListLoader[0] == "EternalGoal")
                {
                    CreateEternalGoal(GoalListLoader[1],GoalListLoader[2],Convert.ToInt32(GoalListLoader[3]));
                }
                else if (GoalListLoader[0] == "ChecklistGoal")
                {
                    CreateChecklistGoal(GoalListLoader[1],GoalListLoader[2],Convert.ToInt32(GoalListLoader[3]),0,0);
                }
            }
        }
        System.Console.WriteLine($"Goals Loaded from {fileName}.");
    }
}