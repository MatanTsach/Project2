public abstract class GameEngine
{
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

    public GameState gameState
    {
        get { return m_gameState; }
    }

    public void resetEngine()
    {
        m_playerIdTurn = 1;
        m_gameState = GameState.GAME_CONTINUE;
    }
}