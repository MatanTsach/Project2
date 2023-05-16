class GameManager {
    private readonly int r_boardSize;
    private readonly bool r_isMultiplayer;
    private int m_player1Score;
    private int m_player2Score;
    public GameManager(int i_boardSize, bool i_isMultiplayer)
     {
        r_boardSize = i_boardSize;
        r_isMultiplayer = i_isMultiplayer;
        m_player1Score = 0;
        m_player2Score = 0;
    }

    public void startGame() {
        
    }
}