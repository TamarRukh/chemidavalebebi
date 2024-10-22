using System;

class Program
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';
    static int movesCount = 0;

    static void Main()
    {
        InitializeBoard();
        while (true)
        {
            Console.Clear();
            DisplayBoard();
            PlayerTurn();

            if (CheckWin())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                break;
            }
            if (CheckDraw())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            SwitchPlayer();
        }
    }

    // Method to initialize the game board
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    // Method to display the game board
    static void DisplayBoard()
    {
        Console.WriteLine("  0   1   2");
        Console.WriteLine(" -----------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + "|");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]} |");
            }
            Console.WriteLine();
            Console.WriteLine(" -----------");
        }
    }

    // Method for getting the player's move
    static void PlayerTurn()
    {
        int row, col;
        while (true)
        {
            Console.WriteLine($"Player {currentPlayer}, enter your move (row,column): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',');


            if (parts.Length == 2 &&
                int.TryParse(parts[0], out row) &&
                int.TryParse(parts[1], out col) &&
                row >= 0 && row < 3 &&
                col >= 0 && col < 3 &&
                board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                movesCount++;
                break;
            }
            Console.WriteLine("Invalid move. Try again.");
        }
    }

    // Method to switch players
    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Alternate player
    }

    // Method to check for a win
    static bool CheckWin()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }
        // Check diagonals
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }
        return false;
    }

    // Method to check for a draw
    static bool CheckDraw()
    {
        return movesCount >= 9;
    }
}