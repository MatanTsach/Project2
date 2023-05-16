using System.Text.RegularExpressions;
public abstract class GameEngine {
    protected GameState m_gameState;
    protected Board m_gameBoard;
    protected readonly string[] m_gameMarks = { "X", "O" };

    protected int m_playerIdTurn = 1;
    public GameEngine(Board i_gameBoard)
    {
        m_gameBoard = i_gameBoard;
        m_gameState = GameState.GAME_CONTINUE;
    }
    public abstract void playTurn();
    protected (int, int) getUserInput()
    {
        Match match;
        int gameBoardSize = m_gameBoard.getBoardSize();
        int x = 0;
        int y = 0;
        string input;
        string pattern = @"\(([1-9]), ([1-9])\)";
        string getCoordsMessage =$"[Player{m_playerIdTurn}] Please enter a cell to insert {m_gameMarks[m_playerIdTurn - 1]} in the format (x, y)";
        string cellAlreadyTakenMessage = "This cell is already taken. Please choose another cell.";
        string incorrectEntryMessage = $"Please enter the row and column in the correct format.\n" + 
                $"Please note: X and Y must be in the bounds of the board. 1 <= x,y <= {gameBoardSize}";
        
        while (true)
        {
            Console.WriteLine(getCoordsMessage);
            input = Console.ReadLine();
            if (input == "Q")
            {
                m_gameState = GameState.GAME_END;
                break;
            }
            match = Regex.Match(input, pattern);
            if (match.Success)
            {
                x = int.Parse(match.Groups[1].Value);
                y = int.Parse(match.Groups[2].Value);
                if(!(x < 1 || y < 1 || x > gameBoardSize || y > gameBoardSize)) {
                    if(!(m_gameBoard.isCellAvailable(x - 1, y - 1)))
                    {
                       Console.WriteLine(cellAlreadyTakenMessage);
                       continue;
                    }
                    break;
                }
            }
            Console.WriteLine(incorrectEntryMessage);
        }
        return (x, y);
    }
}