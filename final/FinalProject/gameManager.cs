public class GameManager
{
    private Player _player;
    private Room[,] _grid;
    private Room _currentRoom;
    private bool _gameRunning;

    public GameManager()
    {

    }
    public void StartGame()
    {
        Player _player = new Player("Player", "The player character", 100); // Example initial health: 100
        Room newMap = new Room();
    }

    public void HandlePlayerInput(string input)
    {

    }
    public void UpdateGameState()
    {
        // Update game state based on player actions
    }

    public void CheckWinCondition()
    {
    }

    public void CheckLoseCondition()
    {
        // Check if player has met lose condition
    }

    public void EndGame()
    {
        // Clean up game resources, display end-game messages, etc.
    }
}