public class MultiPlayerEngine : GameEngine
{
    public MultiPlayerEngine(Board i_gameBoard)
        : base(i_gameBoard)
    {

    }

    public override void playTurn()
    {
        string prefix = $"[Player{m_playerIdTurn}]";
        string sign = m_gameMarks[m_playerIdTurn - 1];
        (int row, int col) = ConsoleUtils.requestUserCellInput(m_gameBoard, prefix, sign, out m_gameState);
        if(!(m_gameState == GameState.GAME_END))
        {
            m_gameBoard.updateBoard(row, col, sign);
            if(BoardUtils.checkWin(m_gameBoard.getBoard(), sign))
            {
                m_gameState = m_playerIdTurn == 1 ? GameState.GAME_PLAYER1_WIN : GameState.GAME_PLAYER2_WIN;
            }
        }
        m_playerIdTurn = m_playerIdTurn == 1 ? 2 : 1;
    }
}