public class GameManager
{
    private Player player;
    private Room currentRoom;
    private bool gameRunning;

    public GameManager()
    {
        gameRunning = true;
    }

    public void StartGame()
    {
        player = new Player("Player", 100, 3, 3, 10); // Player starts at row 3, column 3
        Monster monster = new Monster("Bird", 10, 1, 1, 10); 
        char[,] roomLayout = GenerateRoomLayout();
        currentRoom = new Room(roomLayout);
        Random rand = new Random();
        int numEnemies = rand.Next(1, 6);
        int numTreasures = rand.Next(1, 6);
        // Adds Monsters
        for (int i = 0; i < numEnemies; i++)
        {   
            int enemyRow = rand.Next(1, roomLayout.GetLength(0));
            int enemyCol = rand.Next(1, roomLayout.GetLength(1));
            Monster enemy = new Monster($"Enemy {i + 1}", 10, enemyRow, enemyCol, 5);
            currentRoom.AddMonster(enemy);
        }

        // Add treasures to the room
        for (int i = 0; i < numTreasures; i++)
        {
            int treasureRow = rand.Next(1, roomLayout.GetLength(0));
            int treasureCol = rand.Next(1, roomLayout.GetLength(1));
            Treasure treasure = new Treasure($"Treasure {i + 1}", 1, treasureRow, treasureCol, 0);
            currentRoom.AddTreasure(treasure);
        }
        while (gameRunning)
        {
            Console.Clear();
            System.Console.WriteLine($"Name: {player.GetName()}");
            System.Console.WriteLine($"Health: {player.GetHealth()} , Score: {player.GetScore()}");
            currentRoom.DrawRoomWithPlayer(player.GetRow(), player.GetColumn());
            HandlePlayerInput();
            HandleEvents();
            HandleMonsterInput();
        }
    }
    private void HandlePlayerInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        int playerRow = player.GetRow();
        int playerCol = player.GetColumn();

        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                if (player.CanMoveUp(currentRoom.Layout) && currentRoom.IsPositionEmpty(playerRow - 1, playerCol))
                    player.MoveUp();
                else
                    HandleCollision(playerRow - 1, playerCol);
                break;
            case ConsoleKey.DownArrow:
                if (player.CanMoveDown(currentRoom.Layout) && currentRoom.IsPositionEmpty(playerRow + 1, playerCol))
                    player.MoveDown();
                else
                    HandleCollision(playerRow + 1, playerCol);
                break;
            case ConsoleKey.LeftArrow:
                if (player.CanMoveLeft(currentRoom.Layout) && currentRoom.IsPositionEmpty(playerRow, playerCol - 1))
                    player.MoveLeft();
                else
                    HandleCollision(playerRow, playerCol - 1);
                break;
            case ConsoleKey.RightArrow:
                if (player.CanMoveRight(currentRoom.Layout) && currentRoom.IsPositionEmpty(playerRow, playerCol + 1))
                    player.MoveRight();
                else
                    HandleCollision(playerRow, playerCol + 1);
                break;
            default:
                break;
        }
    }
    private void HandleCollision(int row, int col)
    {
        // Check if the position contains a monster
        foreach (Monster monster in currentRoom.Monsters)
        {
            if (monster.GetRow() == row && monster.GetColumn() == col)
            {
                int playerDamage = player.GetAttackPower();
                int monsterDamage = monster.GetAttackPower();
                player.TakeDamage(monsterDamage);
                monster.TakeDamage(playerDamage);
                if (player.GetHealth() <= 0)
                {
                    gameRunning = false;
                }
                if (monster.GetHealth() <= 0)
                {
                    currentRoom.RemoveMonster(monster);
                }
                break;
            }
        }
        foreach (Treasure treasure in currentRoom.Treasures)
    {
        if (treasure.GetRow() == row && treasure.GetColumn() == col)
        {
            player.PickUpTreasure(treasure);
            currentRoom.RemoveTreasure(treasure);
            return;
        }
    }
    }
    private void HandleMonsterInput()
    {
        currentRoom.MoveMonsters();
    }
    private void HandleEvents() //This should allow damage, and pick ups to happen in the same tick 
    {
        foreach (Monster monster in currentRoom.Monsters)
        {
            if (monster.GetRow() == player.GetRow() && monster.GetColumn() == player.GetColumn())
            {
                int playerDamage = player.GetAttackPower();
                int monsterDamage = monster.GetAttackPower();
                Console.WriteLine($"You dealt {playerDamage} damage to the {monster.GetName()}!");
                Console.WriteLine($"The {monster.GetName()} dealt {monsterDamage} damage to you!");
                player.TakeDamage(monsterDamage);
                monster.TakeDamage(playerDamage);
                if (player.GetHealth() <= 0)
                {
                    gameRunning = false;
                }
                if (monster.GetHealth() <= 0)
                {
                    currentRoom.RemoveMonster(monster);
                }
                break;
            }
        }
    }
    private char[,] GenerateRoomLayout()
    {
        char[,] roomLayout = new char[11, 15];
        for (int i = 0; i < roomLayout.GetLength(0); i++)
        {
            for (int j = 0; j < roomLayout.GetLength(1); j++)
            {
                roomLayout[i, j] = '.';
            }
        }
        return roomLayout;
    }
}