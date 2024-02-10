public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }
    public override void RecordEvent()
    {
        System.Console.WriteLine($"Event Recorded for {GetShortName()}");
    }
    public override bool IsComplete()
    {
        return false; //This goal should never be complete.
    }
    public override string GetStringRepresentation()
    {
        return ($"Eternal Goal: {GetShortName()} - Description: {GetDescription()} - Points: {GetPoints()}");
    }
}