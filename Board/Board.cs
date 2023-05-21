public class Board
{
    private string[,] m_BoardMatrix;
    private int m_BoardSize;

    public Board(int size)
    {
        m_BoardSize = size;
        m_BoardMatrix = new string[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                m_BoardMatrix[row, col] = "   ";
            }
        }

        refreshBoard();
    }

    public string[,] BoardMatrix
    {
        get { return m_BoardMatrix; } 
    }

    public int Size
    {
        get { return m_BoardSize; }
    }

    private void refreshBoard()
    {
        string seperatorLine = " ";

        for (int i = 0; i <= (m_BoardSize * 4); i++)
        {
            seperatorLine += "=";
        }

        Console.Write("  ");
        for (int i = 0; i < m_BoardSize; i++)
        {
            Console.Write(i + 1 + "   ");
        }

        Console.WriteLine("");
        for (int row = 0; row < m_BoardSize; row++)
        {
            for (int column = 0; column < m_BoardSize; column++)
            {
                if (column == 0)
                    Console.Write(row + 1 + "|" + m_BoardMatrix[row, column]);
                else
                {
                    if (column == (m_BoardSize - 1))
                    {
                        Console.WriteLine("|" + m_BoardMatrix[row, column] + "|");
                    }
                    else
                    {
                        Console.Write("|" + m_BoardMatrix[row, column]);
                    }
                }
            }

            Console.WriteLine(seperatorLine);
        }
    }

    public void UpdateBoard(int row, int column, string value)
    {
        m_BoardMatrix[row, column] = " " + value + " ";
        refreshBoard();
    }

    public void ResetBoard()
    {
        for (int row = 0; row < m_BoardSize; row++)
        {
            for (int column = 0; column < m_BoardSize; column++)
            {
                m_BoardMatrix[row, column] = "   ";
            }
        }
        
        refreshBoard();
    }

    public bool IsCellAvailable(int i_Row, int i_Col)
    {
        return string.IsNullOrWhiteSpace(m_BoardMatrix[i_Row, i_Col]);
    }

    public void DisplayScoreTable(int i_player1Score, int i_player2Score)
    {
        Console.WriteLine("Score Table");
        Console.WriteLine("-----------------");
        Console.WriteLine($"Player 1: {i_player1Score} points");
        Console.WriteLine($"Player 2: {i_player2Score} points");
        Console.WriteLine("-----------------");
    }
}