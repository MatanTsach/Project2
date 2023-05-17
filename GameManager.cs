class GameManager {
    private readonly int r_boardSize;
    private readonly bool r_isMultiplayer;
    private int m_player1Score;
    private int m_player2Score;
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
            m_gameBoard.displayScoreTable();
            bool continueGame = ConsoleUtils.askAnotherRound();
            if(!continueGame)
            {
                break;
            }
            m_gameBoard.resetBoard();
            m_gameEngine.resetEngine();
        }
    }

    private void playRound()
    {
        while(true)
        {
            m_gameEngine.playTurn();
            if(m_gameEngine.gameState == GameState.GAME_END)
            {
                break;
            }
            else if(m_gameEngine.gameState == GameState.GAME_PLAYER1_WIN)
            {
                m_player1Score++;
                break;
            } else if(m_gameEngine.gameState == GameState.GAME_PLAYER2_WIN)
            {
                m_player2Score++;
                break;
            }
        }
    }
}