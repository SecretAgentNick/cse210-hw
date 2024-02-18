
public class Player : Entity
{
    private List<Treasure> _inventory;
    public Player(string name, string description, int initialHealth)
        : base(name, description, initialHealth)
    {

    }
}