public class SinglePlayerEngine : GameEngine
{
    public SinglePlayerEngine(Board i_Board)
        : base(i_Board)
    {
    }
    public override void playTurn()
    {
        int row;
        int col;
        string sign = m_gameMarks[m_playerIdTurn - 1];
        if (m_playerIdTurn == 1)
        {
            (row, col) = UI.requestUserCellInput(m_gameBoard, "", "X", out m_gameState);
        }
        else
        {
            Random random = new Random();
            while (true)
            {
                row = random.Next(0, m_gameBoard.getBoardSize());
                col = random.Next(0, m_gameBoard.getBoardSize());

                if (m_gameBoard.isCellAvailable(row, col))
                {
                    break;
                }
            }
        }
        if (!(m_gameState == GameState.GAME_END))
        {
            m_gameBoard.updateBoard(row, col, sign);
            evaluateGameState();
        }
    }
}