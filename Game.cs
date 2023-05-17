
class Game
{
    public static void Main()
    {
        int boardSize = getBoardSize();
        bool gameMode = getMuldiOrSingle();
        //GameManager gameManager = new GameManager(boardSize,gameMode);
        //gameManager.startGame();
        Board b = new Board(boardSize);
        b.refreshMatrix();
        b.updateBoard(3,3,"X");
        b.refreshMatrix();
        b.resetBoard();
        b.refreshMatrix();
        b.displayScoreTable();
    }
    private static int getBoardSize() {
        Console.WriteLine("Welcome to Matan and Dolev's Tic Tac Toe game");
        Console.WriteLine("Please enter a board size:");
        int sizeInputNum = 0;
        while(true)
        {
            if(int.TryParse(Console.ReadLine(), out sizeInputNum))
            {
                if (sizeInputNum >=3 && sizeInputNum <=9)
                {
                    break;
                }
                Console.WriteLine("INVALID INPUT, PLEASE ENTER AGAIN");
            }
        }
        return sizeInputNum;
    }
    // return true if multiplayer false if single
    private static bool getMuldiOrSingle()
    {
        Console.WriteLine("Do you want to play in single or multi player mode?");
        Console.WriteLine("press S form single or M for multi");
        string modeInput;
        while(true)
        {
            modeInput = Console.ReadLine();
            if(modeInput == "S" || modeInput == "M")
            {   
                break;
            }
            else
            {
                Console.WriteLine("INVALID INPUT, PLEASE ENTER AGAIN");
            }
        }
        return modeInput == "M" ? true : false;
    }
}