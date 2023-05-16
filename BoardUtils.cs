public class BoardUtils
{
    public static bool checkWin(string[,] matrix, String i_Sign)
    {
        return evaluateBoardHorizonal(matrix, i_Sign) || evaluateBoardHorizonal(matrix, i_Sign) || evaluateBoardDiagonal(matrix, i_Sign);
    }

    public static bool isBoardFull(string[,] matrix)
    {
        bool isFull = true;
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix.Length; col++)
            {
                if (!string.IsNullOrWhiteSpace(matrix[row, col]))
                {
                    isFull = false;
                }
            }
        }
        return isFull;
    }

    private static bool evaluateBoardHorizonal(string[,] matrix, String i_Sign)
    {
        int maxCount = 0;
        int matrixSize = matrix.Length;
        for (int row = 0; row < matrixSize; row++)
        {
            int count = 0;
            for (int col = 0; col < matrixSize; col++)
            {
                if (matrix[row, col].Trim() == i_Sign)
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

    private static bool evaluateBoardVertical(string[,] matrix, String i_Sign)
    {
        int maxCount = 0;
        int matrixSize = matrix.Length;
        for (int col = 0; col < matrixSize; col++)
        {
            int count = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                if (matrix[row, col].Trim() == i_Sign)
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

    private static bool evaluateBoardDiagonal(string[,] matrix, String i_Sign)
    {
        int matrixSize = matrix.Length;
        int mainDiagonal = 0;
        int oppositeDiagonal = 0;
        for (int i = 0; i < matrixSize; i++)
        {
            mainDiagonal += matrix[i, i].Trim() == i_Sign ? 1 : 0;
            oppositeDiagonal += matrix[matrixSize - 1 - i, matrixSize - 1 - i].Trim() == i_Sign ? 1 : 0;
        }
        return mainDiagonal == matrixSize || oppositeDiagonal == matrixSize;
    }
}