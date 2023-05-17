using System.Text.RegularExpressions;
public class ConsoleUtils
{
    public static (int, int) requestUserCellInput(Board i_Board, String i_Prefix, String i_Sign, out GameState o_gameState)
    {
        Match match;
        int gameBoardSize = i_Board.getBoardSize();
        int x = 0;
        int y = 0;
        string input;
        string pattern = @"\(([1-9]), ([1-9])\)";
        string getCoordsMessage =$"{i_Prefix} Please enter a cell to insert {i_Sign} in the format (x, y)";
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
                if(!(x < 1 || y < 1 || x > gameBoardSize || y > gameBoardSize)) {
                    if(!(i_Board.isCellAvailable(x - 1, y - 1)))
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
        return (x, y);
    }
}