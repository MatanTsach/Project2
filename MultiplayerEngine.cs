using System.Text.RegularExpressions;
public class MultiplayerEngine : GameEngine
{
    public MultiplayerEngine(Board i_gameBoard)
        : base(i_gameBoard)
    {
        
    }

    public override void playTurn()
    {
        (int player1_X, int player2_Y) = getUserInput(1);
        if (!(m_gameState == GameState.GAME_END))
        {   

        }
    }

    public GameState getGameState()
    {
        return 0;
    }


    private bool evaluateBoard()
    {

    }
}