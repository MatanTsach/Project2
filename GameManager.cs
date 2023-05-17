class GameManager {
    private readonly int r_boardSize;
    private readonly bool r_isMultiplayer;
    private static int m_player1Score;
    private static int m_player2Score;
    private GameEngine m_gameEngine;
    private Board m_gameBoard;
    public GameManager(int i_boardSize, bool i_isMultiplayer)
    {
        r_boardSize = i_boardSize;
        r_isMultiplayer = i_isMultiplayer;
        m_gameBoard = new Board(i_boardSize);
        m_gameEngine = r_isMultiplayer ? new MultiPlayerEngine(m_gameBoard) : new SinglePlayerEngine(m_gameBoard);
    }

    public void startGame()
    {
        while(true)
        {
            playRound();
            ConsoleUtils.DisplayEndOfRoundMessage(m_gameEngine.gameState);
            m_gameBoard.displayScoreTable(m_player1Score, m_player2Score);
            bool continueGame = ConsoleUtils.askAnotherRound();
            if(!continueGame)
            {
                break;
            }
            m_gameBoard.resetBoard();
            m_gameEngine.resetEngine();
        }
        ConsoleUtils.sendEndMessage();
    }
    private void playRound()
    {
        bool continueRound = true;
        while(continueRound)
        {
            m_gameEngine.playTurn();
            switch(m_gameEngine.gameState)
            {
                case GameState.GAME_END:
                    continueRound = false;
                    break;
                case GameState.GAME_PLAYER1_LOSS:
                    continueRound = false;
                    m_player2Score++;
                    break;
                case GameState.GAME_PLAYER2_LOSS:
                    continueRound = false;
                    m_player1Score++;
                    break;
                case GameState.GAME_TIE:
                    continueRound = false;
                    break;
                case GameState.GAME_CONTINUE:
                    break;
            }
            m_gameEngine.changePlayerTurn();
        }
    }
}