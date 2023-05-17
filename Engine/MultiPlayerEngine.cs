public class MultiPlayerEngine : GameEngine
{
    public MultiPlayerEngine(Board i_gameBoard)
        : base(i_gameBoard)
    {
    }

    public override void playTurn()
    {
        string prefix = $"[Player{m_playerIdTurn}] ";
        string sign = m_gameMarks[m_playerIdTurn - 1];
        (int row, int col) = UI.requestUserCellInput(m_gameBoard, prefix, sign, out m_gameState);
        if(!(m_gameState == GameState.GAME_END))
        {
            m_gameBoard.updateBoard(row, col, sign);
            evaluateGameState();
        }
    }
}