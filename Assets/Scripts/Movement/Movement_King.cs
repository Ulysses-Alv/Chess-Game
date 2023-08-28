using MovementInterfaces;

public class Movement_King : IKing
{
    public void ShowAvailableCaptures(int initialCol, int initialFila, Piece piece)
    {
        ShowAvailableCaptures_King(initialCol, initialFila, piece);
    }
    public void ShowAvailableMoves(int initialCol, int initialFila, Piece piece)
    {
        ShowAvailableMoves_King(initialCol, initialFila, piece);
    }

    public void ShowAvailableCaptures_King(int initialCol, int initialFila, Piece piece)
    {
    }

    public void ShowAvailableMoves_King(int initialCol, int initialFila, Piece piece)
    {
        ColorDePieza color = piece.color;

        for (int col = -1; col <= 1; col++)
        {
            for (int fila = -1; fila <= 1; fila++)
            {
                int col_newCell = initialCol + col;
                int fila_newCell = initialFila + fila;

                if (Board.ExceedTheBoard(col_newCell, fila_newCell) || (col == 0 && fila == 0)) continue;

                Cell cell = Board.GetCell(col_newCell, fila_newCell).GetComponent<Cell>();

                if (cell.PieceOnThisCell != null)
                {
                    if (cell.PieceOnThisCell.GetComponent<Piece>().color != color)
                        cell.ActivateRed();
                    break;
                }
                cell.ActivateBlueCell();
            }
        }
    }
}

