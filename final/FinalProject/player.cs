using System.Runtime.CompilerServices;

public class Player : Entity
{
    private int _score;
    public Player(string name, int initialHealth, int initialRow, int initialColumn, int attackPower) : base (name, initialHealth, initialRow, initialColumn, attackPower)
    {
        _score = 0;
    }
    public override bool IsPlayer()
    {
        return true;
    }
    public int GetScore()
    {
        return _score;
    }
    public void PickUpTreasure(Treasure treasure)
    {
        int addToScore = treasure.GetWorth();
        this.addToScore(addToScore);
    }
    public void addToScore(int num)
    {
        _score+=num;
    }
}