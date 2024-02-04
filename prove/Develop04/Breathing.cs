public class Breathing : Activity
{
    public Breathing(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void InandOut(int seconds)
    {
        for (int i = 0; i < seconds/2; i++)
        {
            if (i%2 != 0) 
            {
                Console.WriteLine("Breath Out.\n");
            }
            else 
            {
                Console.WriteLine("Breath In.\n");
            }
            Thread.Sleep(2000);
        }
    }
}