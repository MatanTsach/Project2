public class MultiPlayerEngine : GameEngine
{
    public MultiPlayerEngine(Board i_gameBoard)
        : base(i_gameBoard)
    {}

    public override void PlayTurn()
    {
        string prefix = $"[Player{m_PlayerIdTurn}] ";
        string sign = r_GameMarks[m_PlayerIdTurn - 1];
        (int row, int col) = UI.RequestUserCellInput(m_GameBoard, prefix, sign, out m_GameState);
        
        if(!(m_GameState == eGameState.GAME_END))
        {
            m_GameBoard.UpdateBoard(row, col, sign);
            EvaluateGameState();
        }
    }
}