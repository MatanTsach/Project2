using System.Text.RegularExpressions;
public abstract class GameEngine {
    private GameState m_gameState;
    private Board m_gameBoard;
    private readonly string[] m_gameMarks = { "X", "O" };

    public GameEngine(BoardUtils i_gameBoard)
    {
        m_gameBoard = i_gameBoard;
        m_gameState = GameState.GAME_CONTINUE;
    }
    public abstract void playTurn();
    private (int, int) getUserInput(int i_playerId)
    {
        string input;
        string pattern = @"\(([1-9]), ([1-9])\)";
        int gameBoardSize = m_gameBoard.getBoardSize();
        int x = 0;
        int y = 0;
        Match match;
        while (true)
        {
            Console.WriteLine($"[Player{i_playerId}] Please enter a cell to insert {m_gameMarks[i_playerId - 1]} in the format (x, y)");
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
                    break;
                }
            }
            Console.WriteLine($"Please enter the row and column in the correct format.\n" + 
                $"Please note: X and Y must be in the bounds of the board. 1 <= x,y <= {gameBoardSize}");
        }
        return (x, y);
    }
}