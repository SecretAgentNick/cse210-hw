public abstract class Entity
{
    private string _name;
    private int _health;
    private int _row;
    private int _column;
    private int _attackPower;

    public string GetName()
    {
        return _name;
    }
    public int GetHealth()
    {
        return _health;
    }
    public int GetRow()
    {
        return _row;
    }
    public int GetColumn()
    {
        return _column;
    }
    public int GetAttackPower()
    {
        return _attackPower;
    }
    public Entity(string name, int initialHealth, int initialRow, int initialColumn, int attackPower)
    {
        _name = name;
        _health = initialHealth;
        _row = initialRow;
        _column = initialColumn;
        _attackPower = attackPower;
    }
    public void MoveUp()
    {
        _row--;
    }
    public void MoveDown()
    {
        _row++;
    }
    public void MoveLeft()
    {
        _column--;
    }
    public void MoveRight()
    {
        _column++;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
            _health = 0;
    }
    public bool CanMoveUp(char[,] roomLayout)
    {
        return _row > 0 && roomLayout[_row - 1, _column] != '#'; // '#' represents a wall
    }
    public bool CanMoveDown(char[,] roomLayout)
    {
        return _row < roomLayout.GetLength(0) - 1 && roomLayout[_row + 1, _column] != '#';
    }
    public bool CanMoveLeft(char[,] roomLayout)
    {
        return _column > 0 && roomLayout[_row, _column - 1] != '#';
    }
    public bool CanMoveRight(char[,] roomLayout)
    {
        return _column < roomLayout.GetLength(1) - 1 && roomLayout[_row, _column + 1] != '#';
    }
    public abstract bool IsPlayer();
}