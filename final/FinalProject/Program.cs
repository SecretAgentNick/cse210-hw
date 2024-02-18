using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();

        while (true)
        {
            DisplayGameState(gameManager);
            string input = Console.ReadLine();
            gameManager.HandlePlayerInput(input);
            gameManager.UpdateGameState();
            gameManager.CheckWinCondition();
            gameManager.CheckLoseCondition();
            if (input == "`") //top left of keyboard.
            {
                break;
            }
        }
        gameManager.EndGame();
    }

    static void DisplayGameState(GameManager gameManager)
    {
        Console.Clear();
    }
}
