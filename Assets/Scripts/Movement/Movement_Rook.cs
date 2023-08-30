using MovementInterfaces;

public class Movement_Rook : IRook
{
    public void ShowAvailableMoves(int initialCol, int initialFila, PieceBase piece)
    {
        ShowAvailableMoves_Rook(initialCol, initialFila, piece);
    }

    public void ShowAvailableMoves_Rook(int initialCol, int initialFila, PieceBase piece)
    {
        ColorDePieza color = piece.colorDePieza;

        for (int movement = -8; movement < 8; movement++)
        {
            int col_newCell = initialCol + movement;

            if (col_newCell < 1 || col_newCell > 8) continue;

            Cell cell = BoardAccess.GetCellGO(col_newCell, initialFila).GetComponent<Cell>();

            cell.ActivateBlueCell();
        }
        for (int movement = -8; movement < 8; movement++)
        {
            int fila_newCell = initialFila + movement;

            if (fila_newCell < 1 || fila_newCell > 8) continue;

            Cell cell = BoardAccess.GetCellGO(initialCol, fila_newCell).GetComponent<Cell>();

            cell.ActivateBlueCell();
        }
    }
}