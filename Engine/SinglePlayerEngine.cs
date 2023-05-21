public class SinglePlayerEngine : GameEngine
{
    public SinglePlayerEngine(Board i_Board)
        : base(i_Board)
    {}

    public override void PlayTurn()
    {
        int row;
        int col;
        string sign = r_GameMarks[m_PlayerIdTurn - 1];

        if (m_PlayerIdTurn == 1)
        {
            (row, col) = UI.RequestUserCellInput(m_GameBoard, "", "X", out m_GameState);
        }
        else
        {
            Random random = new Random();
            while (true)
            {
                row = random.Next(0, m_GameBoard.Size);
                col = random.Next(0, m_GameBoard.Size);
                if (m_GameBoard.IsCellAvailable(row, col))
                {
                    break;
                }
            }
        }
        
        if (!(m_GameState == eGameState.GAME_END))
        {
            m_GameBoard.UpdateBoard(row, col, sign);
            EvaluateGameState();
        }
    }
}