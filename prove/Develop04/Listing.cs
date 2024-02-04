public class Listing : Activity
{
    private Random _rndNumber = new Random();
    private List<string> _randomListing = new List<string>
    {
    "Who are people that you appreciate?"
    ,"What are personal strengths of yours?"
    ,"Who are people that you have helped this week?"
    ,"When have you felt the Holy Ghost this month?"
    ,"Who are some of your personal heroes?"
    };
    public Listing(string name, string description, int duration) : base(name, description, duration)
    {
    }
    public void Prompt(int seconds)
    {
        int promptNum = _rndNumber.Next(0,_randomListing.Count);
        List<string> userResponse = new List<string>();
        int counter = 0;
        Console.WriteLine(_randomListing[promptNum]);
        while (seconds > 0)
        {
            Console.WriteLine("Please enter a Response:");
            userResponse.Add(Console.ReadLine());
            seconds-=1;
        }
        Console.Clear();
        for (int i = 0; i < userResponse.Count; i++)
        {
            Console.WriteLine(userResponse[i]);
            counter+=1;
        }
        System.Console.WriteLine($"You responded {counter} times.");
    }
}