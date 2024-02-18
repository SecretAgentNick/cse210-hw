public class Monster : Entity
{
    private int _damage;
    private int _attackRange;
    private int _aggressionLevel;

    public Monster(string name, string description, int initialHealth, int damage, int attackRange, int aggressionLevel)
        : base(name, description, initialHealth)
    {
        this._damage = damage;
        this._attackRange = attackRange;
        this._aggressionLevel = aggressionLevel;
    }
}
