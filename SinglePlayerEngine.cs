public class SinglePlayerEngine : GameEngine
{
    public SinglePlayerEngine(Board i_Board)
        : base(i_Board)
    {
    }
    public override void playTurn()
    {
        Random random = new Random();
        int randomRow;
        int randomColumn;
            if(m_playerIdTurn == 1)
            {
                (int rowInput, int columnInput) = getUserInput();
                m_gameBoard.updateBoard(rowInput,columnInput,"X");
                if(BoardUtils.checkWin(m_gameBoard.getBoard(),"X"))
                GameManager.increasePlayerScore(1);
            }
            else
            {
                while(true)
                {
                    randomRow = random.Next(1,m_gameBoard.getBoardSize());
                    randomColumn = random.Next(1,m_gameBoard.getBoardSize());
                    
                    if(m_gameBoard.isCellAvailable(randomRow, randomColumn))
                    {
                        m_gameBoard.updateBoard(randomRow,randomColumn,"O");
                        break;
                    }
                }   
                    if(BoardUtils.checkWin(m_gameBoard.getBoard(),"O"))
                    GameManager.increasePlayerScore(2);
                 
            }
            m_playerIdTurn = m_playerIdTurn == 1 ? 2 : 1;
        
    }
}