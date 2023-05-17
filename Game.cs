
class Game
{
    public static void Main()
    {
        ConsoleUtils.sendWelcomeMessage();
        int boardSize = ConsoleUtils.getBoardSize();
        bool gameMode = ConsoleUtils.isMultiplayerOrSingle();
        GameManager gameManager = new GameManager(boardSize, gameMode);
        gameManager.startGame();
    }
    
}