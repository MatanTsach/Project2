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

    public void changePlayerTurn()
    {
        m_playerIdTurn = m_playerIdTurn == 1 ? 2 : 1;
    }

    public void evaluateGameState()
    {
        if(BoardUtils.checkLoss(m_gameBoard.getBoard(), m_gameMarks[m_playerIdTurn-1]))
        {
            m_gameState = m_playerIdTurn == 1 ? GameState.GAME_PLAYER1_LOSS : GameState.GAME_PLAYER2_LOSS;
        }
        else if(BoardUtils.isBoardFull(m_gameBoard.getBoard()))
        {
            m_gameState = GameState.GAME_TIE;
        }
    }
}