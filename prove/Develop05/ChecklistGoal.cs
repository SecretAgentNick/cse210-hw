using System.Runtime.CompilerServices;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int repeat, int bonus) : base(shortName , description , points)
    {
        _target = repeat;
        _bonus = bonus;
    }
    public override void RecordEvent()
    {
        _amountCompleted+=1;
        System.Console.WriteLine($"Event Recorded: {GetShortName()}");
        if (_amountCompleted == _target)
        {
            IsComplete();
        }
    }
    public override bool IsComplete()
    {
        return (_amountCompleted >= _target);
    }
    public override string GetStringRepresentation()
    {
        return ($"Checklist Goal: {GetShortName()} - Description: {GetDescription()} - Completed: {_amountCompleted}/{_target} - Points: {GetPoints()}");
    }
    public string GetDetailString()
    {
        return ($"{GetShortName()} {GetDescription()} - Completed: {_amountCompleted}/{_target} - Points: {GetPoints()}");
    }
}