using System.Text.RegularExpressions;

public class UI
{

    public static void sendWelcomeMessage()
    {
        Console.WriteLine("Welcome to Matan and Dolev's Reverse Tic Tac Toe game");
    }

    public static void sendEndMessage()
    {
        Console.WriteLine("Thank you for playing our game :-).");
    }

    public static void DisplayEndOfRoundMessage(GameState i_gameState)
    {
        switch(i_gameState)
        {
            case GameState.GAME_PLAYER1_LOSS:
                Console.WriteLine("Player2 has won the game!.");
                break;
            case GameState.GAME_PLAYER2_LOSS:
                Console.WriteLine("Player1 has won the game!.");
                break;
            case GameState.GAME_TIE:
                Console.WriteLine("The board is full, therefore the round ended in a tie!.");
                break;
        }
    }

    public static int getBoardSize()
    {
        Console.WriteLine("Please enter a board size:");
        int sizeInputNum = 0;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out sizeInputNum))
            {
                if (sizeInputNum >= 3 && sizeInputNum <= 9)
                {
                    break;
                }
                Console.WriteLine("INVALID INPUT, PLEASE ENTER AGAIN");
            }
        }
        return sizeInputNum;
    }

    public static bool isMultiplayerOrSingle()
    {
        Console.WriteLine("Do you want to play in single or multi player mode?");
        Console.WriteLine("press S for single or M for multiplayer");
        string modeInput = Console.ReadLine();
        while (modeInput != "S" && modeInput != "M")
        {
            Console.WriteLine("Invalid input, please enter S for single and M for multiplayer");
            modeInput = Console.ReadLine();
        }
        return modeInput == "M" ? true : false;
    }
    public static (int, int) requestUserCellInput(Board i_Board, String i_Prefix, String i_Sign, out GameState o_gameState)
    {
        Match match;
        int gameBoardSize = i_Board.getBoardSize();
        int x = 0;
        int y = 0;
        string input;
        string pattern = @"\(([1-9]), ([1-9])\)";
        string getCoordsMessage = $"{i_Prefix}Please enter a cell to insert {i_Sign} in the format (x, y)";
        string cellAlreadyTakenMessage = "This cell is already taken. Please choose another cell.";
        string incorrectEntryMessage = $"Please enter the row and column in the correct format.\n" +
                $"Please note: X and Y must be in the bounds of the board. 1 <= x,y <= {gameBoardSize}";
        while (true)
        {
            Console.WriteLine(getCoordsMessage);
            input = Console.ReadLine();
            if (input == "Q")
            {
                o_gameState = GameState.GAME_END;
                break;
            }
            match = Regex.Match(input, pattern);
            if (match.Success)
            {
                x = int.Parse(match.Groups[1].Value);
                y = int.Parse(match.Groups[2].Value);
                if (!(x < 1 || y < 1 || x > gameBoardSize || y > gameBoardSize))
                {
                    if (!(i_Board.isCellAvailable(x - 1, y - 1)))
                    {
                        Console.WriteLine(cellAlreadyTakenMessage);
                        continue;
                    }
                    o_gameState = GameState.GAME_CONTINUE;
                    break;
                }
            }
            Console.WriteLine(incorrectEntryMessage);
        }
        return (x - 1, y - 1);
    }
    public static bool askAnotherRound()
    {
        Console.WriteLine("Would you like to play another round?");
        Console.WriteLine("Type 'Y' for Yes and any other key to quit.");
        return Console.ReadLine() == "Y";
    }
}