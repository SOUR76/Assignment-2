/*
Dominik Michalak
1. Initialize the board
2. Set the starting player to X or O
3. Start the game and continue it untill the board is full or there is a winner
4. Update the board
5. Switch player
6. Display illegal moves
7. Display final board
8. Check for a winner and print the result
9. Extend the game with menu
10. Add the score
 
 */
class Program
{
    static int playerXScore = 0;
    static int playerOScore = 0;
    static void Main()
    {
        bool exitGame = false;
        do
        {
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. About the author");
            Console.WriteLine("3. Exit");
            Console.Write("> ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PlayGame();
                    break;
                case "2":
                    Console.WriteLine("My name is Dominik. I'm 20 years old. I'm a student at WSB Merito University in Poznan");
                    Console.WriteLine("[Press Eneter to return to main menu]");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Are you sure you want to exit? [yes/no]");
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "yes") ;
                    {
                        exitGame = true;
                        Console.WriteLine("Goodbye!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (!exitGame);
    }
    static void PlayGame()
    {
        char[,] board = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        char currentPlayer = (new Random().Next(2) == 0) ? 'X' : 'O';
        Console.WriteLine("Welcome to tic-tac-toe game!");
        while (!FullBoard(board) && !Winner(board))
        {
            PrintBoard(board);
            Console.WriteLine($"Score: Player X - {playerXScore}, Player O - {playerOScore}");
            Console.Write($"{currentPlayer}'s move > ");
            int move;

            if (int.TryParse(Console.ReadLine(), out move) && ValidMove(move, board))
            {
                MakeMove(currentPlayer, move, board);

                if (Winner(board))
                {
                    Console.WriteLine($"{currentPlayer} wins! Game over.");
                    UpdateScore(currentPlayer);
                    DisplayScore();
                    break;
                }
                else if (FullBoard(board))
                {
                    Console.WriteLine("It's a draw! Game over.");
                    DisplayScore();
                    break;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }
        }
        Console.WriteLine("[Press Eneter to return to main menu...]");
        Console.ReadLine();
    }
    static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2)
                Console.WriteLine("-----------");
        }
        Console.WriteLine();
    }
    static bool ValidMove(int move, char[,] board)
    {
        int row = (move - 1) / 3;
        int coll = (move - 1) % 3;
        return 1 <= move && move <= 9 && board[row, coll] == ' ';
    }
    static void MakeMove(char player, int move, char[,] board)
    {
        int row = (move - 1) / 3;
        int coll = (move - 1) % 3;
        board[row, coll] = player;
    }
    static bool FullBoard(char[,] board)
    {
        foreach (var cell in board)
        {
            if (cell == ' ')
                return false;
        }
        return true;
    }
    static bool Winner(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
        }
        for (int j = 0; j < 3; j++)
        {
            if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                return true;
        }
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;
        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }
    static void UpdateScore(char currentPlayer)
    {
        if (currentPlayer == 'X')
        {
            playerXScore++;

        }
        else
        {
            playerOScore++;
        }

    }
    static void DisplayScore()
    {
        Console.WriteLine($"Score: Player X - {playerXScore}, Player O - {playerOScore}");
    }
}