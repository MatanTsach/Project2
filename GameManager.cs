class GameManager {
    private readonly int r_BoardSize;
    private readonly bool r_IsMultiplayer;
    private readonly GameEngine r_GameEngine;
    private readonly Board r_GameBoard;
    private int m_Player1Score;
    private int m_Player2Score;

    public GameManager(int i_boardSize, bool i_isMultiplayer)
    {
        r_BoardSize = i_boardSize;
        r_IsMultiplayer = i_isMultiplayer;
        r_GameBoard = new Board(i_boardSize);
        r_GameEngine = r_IsMultiplayer ? new MultiPlayerEngine(r_GameBoard) : new SinglePlayerEngine(r_GameBoard);
    }

    public void StartGame()
    {
        while(true)
        {
            playRound();
            UI.DisplayEndOfRoundMessage(r_GameEngine.State);
            r_GameBoard.DisplayScoreTable(m_Player1Score, m_Player2Score);
            bool continueGame = UI.AskAnotherRound();
            if(!continueGame)
            {
                break;
            }

            r_GameBoard.ResetBoard();
            r_GameEngine.ResetEngine();
        }

        UI.DisplayEndMessage();
    }

    private void playRound()
    {
        bool continueRound = true;
        while(continueRound)
        {
            r_GameEngine.PlayTurn();
            switch(r_GameEngine.State)
            {
                case eGameState.GAME_END:
                    continueRound = false;
                    break;
                case eGameState.GAME_PLAYER1_LOSS:
                    continueRound = false;
                    m_Player2Score++;
                    break;
                case eGameState.GAME_PLAYER2_LOSS:
                    continueRound = false;
                    m_Player1Score++;
                    break;
                case eGameState.GAME_TIE:
                    continueRound = false;
                    break;
                case eGameState.GAME_CONTINUE:
                    break;
            }
            
            r_GameEngine.ChangeTurn();
        }
    }
}