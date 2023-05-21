
class Game
{
    public static void Main()
    {
        UI.DisplayWelcomeMessage();
        int boardSize = UI.AskBoardSize();
        bool gameMode = UI.AskMultiplayerOrSingle();
        GameManager gameManager = new GameManager(boardSize, gameMode);
        gameManager.StartGame();
    }
    
}