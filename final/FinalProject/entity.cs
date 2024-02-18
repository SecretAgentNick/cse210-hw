public class Entity
{
    private string _name;
    private string _description;
    private (int _row, int _column) _position;
    private int _health;
    public Entity(string name, string description, int initialHealth)
    {
        this._name = name;
        this._description = description;
        this._health = initialHealth;
    }
}