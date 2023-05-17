public class Board
{
    private string[,] matrix;
    private int m_matrixSize;
    public string[,] getBoard()
    {
        return matrix;
    }
    public int getBoardSize()
    {
        return m_matrixSize;
    }
    public Board(int size)
    {
        m_matrixSize = size;
        matrix = new string[size,size];
        for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    matrix[row, column] = "   "; 
                }
            }
    }
    public void refreshMatrix()
    {
        string seperatorLine =" ";
        for (int i = 0 ; i <=(m_matrixSize * 4); i++)
        {
            seperatorLine += "=";
        }
        Console.Write("  ");
        for (int i = 0; i < m_matrixSize; i++)
        {
            Console.Write( i +1 + "   ");
        }
        Console.WriteLine("");
        for (int row = 0; row < m_matrixSize; row++)
            {
                for (int column = 0; column < m_matrixSize; column++)
                {
                    if (column == 0)
                        Console.Write(row+1 + "|" + matrix[row,column]);
                    else
                    {
                        if(column == (m_matrixSize-1))
                        Console.WriteLine("|" + matrix[row,column] + "|");
                        else
                        Console.Write("|" + matrix[row,column]);
                    }
                }
                Console.WriteLine(seperatorLine);
            }
    }
    public void updateBoard(int row, int column, string value)
    {
        if(row <= m_matrixSize && row >= 0 && column <= m_matrixSize && column >= 0)
        {
            if (matrix[row,column] == "   ")
            {
                matrix[row,column] = " " + value + " " ;
            }
        }
    }  
    public void resetBoard()
    {
        for (int row = 0; row < m_matrixSize; row++)
            {
                for (int column = 0; column < m_matrixSize; column++)
                {
                    matrix[row, column] = "   "; 
                }
            }
    }  
    public bool isCellAvailable(int i_Row, int i_Col)
    {
        return string.IsNullOrWhiteSpace(matrix[i_Row, i_Col]);
    }
    public void displayScoreTable()
    {
        int player1Score = GameManager.getPlayerScore(1);
        int player2Score = GameManager.getPlayerScore(2);
        Console.WriteLine("Score Table");
        Console.WriteLine("-----------------");
        Console.WriteLine($"Player 1: {player1Score} points");
        Console.WriteLine($"Player 2: {player2Score} points");
    }
}