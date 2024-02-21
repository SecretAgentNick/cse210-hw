public class Monster : Entity
{
    private int _cooldown;
    public Monster(string name, int initialHealth, int initialRow, int initialColumn, int attackPower) : base (name, initialHealth, initialRow, initialColumn, attackPower)
    {
        _cooldown = 1;
    }
    public int GetCooldown()
    {
        return _cooldown;
    }

    public override bool IsPlayer()
    {
        return false;
    }
    public void ResetCooldown()
    {
        _cooldown = 3;

    }

    public void DecrementCooldown()
    {
        _cooldown = Math.Max(0, _cooldown - 1);
    }
}