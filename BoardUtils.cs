public class BoardUtils {
    public static bool checkWin(Board i_Board)
    {
        int size = i_Board.getLength();
        return evaluateBoardDiagonal(i_Board, size) || evaluateBoardHorizonal(i_Board, size) || evaluateBoardVertical(i_Board, size);
    }

    public static bool isBoardFull(Board i_Board)
    {
        return true;
    }

    private static bool evaluateBoardHorizonal(Board i_Board, int size)
    {
        
    }

    private static bool evaluateBoardDiagonal(Board i_Board, int size)
    {

    }

    private static bool evaluateBoardVertical(Board i_Board, int size)
    {

    }
}