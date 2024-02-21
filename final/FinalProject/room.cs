using System;
using System.Collections.Generic;

public class Room
{
    private readonly char[,] _layout;
    private List<Treasure> _treasures;
    private List<Monster> _monsters;

    public Room(char[,] layout)
    {
        _layout = layout;
        _treasures = new List<Treasure>();
        _monsters = new List<Monster>();
    }

    public char[,] Layout
    {
        get { return _layout; }
    }

    public List<Treasure> Treasures
    {
        get { return _treasures; }
    }

    public List<Monster> Monsters
    {
        get { return _monsters; }
    }

    public void AddTreasure(Treasure treasure)
    {
        _treasures.Add(treasure);
    }
    public void RemoveTreasure(Treasure treasure)
    {
        _treasures.Remove(treasure);
    }

    public void AddMonster(Monster monster)
    {
        _monsters.Add(monster);
    }
    public void RemoveMonster(Monster monster)
    {
        _monsters.Remove(monster);
    }
    public void DrawRoomWithPlayer(int playerRow, int playerCol)
    {
        for (int i = 0; i < _layout.GetLength(0); i++)
        {
            for (int j = 0; j < _layout.GetLength(1); j++)
            {
                // Draw player
                if (i == playerRow && j == playerCol)
                {
                    Console.Write('@');
                }
                // Draw treasures
                else if (ContainsTreasure(i, j))
                {
                    Console.Write('$');
                }
                // Draw monsters
                else if (ContainsMonster(i, j))
                {
                    Console.Write('M');
                }
                else
                {
                    Console.Write(_layout[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
    private bool ContainsTreasure(int row, int col)
    {
        foreach (var treasure in _treasures)
        {
            if (treasure.GetRow() == row && treasure.GetColumn() == col)
            {
                return true;
            }
        }
        return false;
    }
    private bool ContainsMonster(int row, int col)
    {
        foreach (var monster in _monsters)
        {
            if (monster.GetRow() == row && monster.GetColumn() == col)
            {
                return true;
            }
        }
        return false;
    }
    public bool IsPositionEmpty(int row, int col)
    {
        return _layout[row, col] != '#' && !ContainsTreasure(row, col) && !ContainsMonster(row, col);
    }
    public void MoveMonsters()
    {
        foreach (var monster in _monsters)
        {
            if (monster.GetCooldown() <= 0)
            {
                Random random = new Random();
                int direction = random.Next(4);
                switch (direction)
                {
                    case 0: // Up
                        if (monster.CanMoveUp(_layout) && IsPositionEmpty(monster.GetRow() - 1, monster.GetColumn()))
                            monster.MoveUp();
                        break;
                    case 1: // Down
                        if (monster.CanMoveDown(_layout) && IsPositionEmpty(monster.GetRow() + 1, monster.GetColumn()))
                            monster.MoveDown();
                        break;
                    case 2: // Left
                        if (monster.CanMoveLeft(_layout) && IsPositionEmpty(monster.GetRow(), monster.GetColumn() - 1))
                            monster.MoveLeft();
                        break;
                    case 3: // Right
                        if (monster.CanMoveRight(_layout) && IsPositionEmpty(monster.GetRow(), monster.GetColumn() + 1))
                            monster.MoveRight();
                        break;
                    default:
                        break;
                }
                // Reset the cooldown timer
                monster.ResetCooldown();
            }
            else
            {
                // Decrement the cooldown timer
                monster.DecrementCooldown();
            }
        }
    }
}
