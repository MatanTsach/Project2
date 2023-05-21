public class BoardUtils
{
    public static bool CheckLoss(string[,] i_Matrix, String i_Sign)
    {
        return evaluateBoardHorizonal(i_Matrix, i_Sign) || evaluateBoardVertical(i_Matrix, i_Sign) || evaluateBoardDiagonal(i_Matrix, i_Sign);
    }

    public static bool IsBoardFull(string[,] i_Matrix)
    {
        bool isFull = true;
        int matrixSize = i_Matrix.GetLength(0);

        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                if (string.IsNullOrWhiteSpace(i_Matrix[row, col]))
                {
                    isFull = false;
                }
            }
        }

        return isFull;
    }
    
    private static bool evaluateBoardHorizonal(string[,] i_Matrix, String i_Sign)
    {
        int maxCount = 0;
        int matrixSize = i_Matrix.GetLength(0);

        for (int row = 0; row < matrixSize; row++)
        {
            int count = 0;
            for (int col = 0; col < matrixSize; col++)
            {
                if (i_Matrix[row, col].Trim() == i_Sign)
                {
                    count++;
                }
            }

            maxCount = maxCount > count ? maxCount : count;
            if (maxCount == matrixSize)
            {
                break;
            }
        }

        return maxCount == matrixSize;
    }

    private static bool evaluateBoardVertical(string[,] i_Matrix, String i_Sign)
    {
        int maxCount = 0;
        int matrixSize = i_Matrix.GetLength(0);

        for (int col = 0; col < matrixSize; col++)
        {
            int count = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                if (i_Matrix[row, col].Trim() == i_Sign)
                {
                    count++;
                }
            }

            maxCount = maxCount > count ? maxCount : count;
            if (maxCount == matrixSize)
            {
                break;
            }
        }

        return maxCount == matrixSize;
    }

    private static bool evaluateBoardDiagonal(string[,] i_Matrix, String i_Sign)
    {
        int matrixSize = i_Matrix.GetLength(0);
        int mainDiagonal = 0;
        int oppositeDiagonal = 0;

        for (int i = 0; i < matrixSize; i++)
        {
            mainDiagonal += (i_Matrix[i, i].Trim() == i_Sign ? 1 : 0);
            oppositeDiagonal += (i_Matrix[i, matrixSize - 1 - i].Trim() == i_Sign ? 1 : 0);
        }
        
        return mainDiagonal == matrixSize || oppositeDiagonal == matrixSize;
    }
}