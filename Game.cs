
class Game
{
    public static void Main()
    {
        UI.sendWelcomeMessage();
        int boardSize = UI.getBoardSize();
        bool gameMode = UI.isMultiplayerOrSingle();
        GameManager gameManager = new GameManager(boardSize, gameMode);
        gameManager.startGame();
    }
    
}