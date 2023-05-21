public abstract class GameEngine
{
    protected eGameState m_GameState;
    protected Board m_GameBoard;
    protected readonly string[] r_GameMarks = { "X", "O" };
    protected int m_PlayerIdTurn = 1;

    public GameEngine(Board i_gameBoard)
    {
        m_GameBoard = i_gameBoard;
        m_GameState = eGameState.GAME_CONTINUE;
    }

    public abstract void PlayTurn();

    public eGameState State
    {
        get { return m_GameState; }
    }

    public void ResetEngine()
    {
        m_PlayerIdTurn = 1;
        m_GameState = eGameState.GAME_CONTINUE;
    }

    public void ChangeTurn()
    {
        m_PlayerIdTurn = m_PlayerIdTurn == 1 ? 2 : 1;
    }

    protected void EvaluateGameState()
    {
        if(BoardUtils.CheckLoss(m_GameBoard.BoardMatrix, r_GameMarks[m_PlayerIdTurn-1]))
        {
            m_GameState = m_PlayerIdTurn == 1 ? eGameState.GAME_PLAYER1_LOSS : eGameState.GAME_PLAYER2_LOSS;
        }
        else if(BoardUtils.IsBoardFull(m_GameBoard.BoardMatrix))
        {
            m_GameState = eGameState.GAME_TIE;
        }
    }
}