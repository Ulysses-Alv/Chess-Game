using MovementInterfaces;
using System;
class Movement_Bishop : IBishop
{

    public void ShowAvailableMoves(int initialCol, int initialFila, Piece piece)
    {
            ShowAvailableMoves_Bishop(initialCol, initialFila, piece);
    }

    public void ShowAvailableMoves_Bishop(int initialCol, int initialFila, Piece piece)
    {
        ColorDePieza color = piece.color;

        foreach (int i in new[] { -1, 1 })
        {
            for (int movement = 0; movement < 8; movement++)
            {
                int col_newCell = initialCol + movement * i;
                int fila_newCell = initialFila + movement * i;
                if (col_newCell < 1 || col_newCell > 8 || fila_newCell < 1 || fila_newCell > 8) continue;

                Cell cell = Board.GetCell(col_newCell, fila_newCell).GetComponent<Cell>();

                if (col_newCell != initialCol && fila_newCell != initialFila
                    && cell.PieceOnThisCell != null)
                {
                    if (cell.PieceOnThisCell.GetComponent<Piece>().color != color)
                        cell.ActivateRed();
                    break;
                }
                cell.ActivateBlueCell();
            }
            for (int movement = 0; movement < 8; movement++)
            {
                int col_newCell = initialCol + movement * i;
                int fila_newCell = initialFila + movement * -1 * i;

                if (col_newCell < 1 || col_newCell > 8 || fila_newCell < 1 || fila_newCell > 8) continue;

                Cell cell = Board.GetCell(col_newCell, fila_newCell).GetComponent<Cell>();

                if (col_newCell != initialCol && fila_newCell != initialFila
                    && cell.PieceOnThisCell != null)
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
