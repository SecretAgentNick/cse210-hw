public class Treasure : Entity
{
    private int _worth;
    public Treasure(string name, int initialHealth, int initialRow, int initialColumn, int attackPower) : base (name, initialHealth, initialRow, initialColumn, attackPower)
    {
        _worth = 10;
    }
    public override bool IsPlayer()
    {
        return false;
    }
    public int GetWorth()
    {
        return _worth;
    }
}