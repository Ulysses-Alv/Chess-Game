using MovementInterfaces;
using System;

public class Movement_King : IKing
{
    public void ShowAvailableMoves(int initialCol, int initialFila, Piece piece)
    {
        ShowAvailableMoves_King(initialCol, initialFila, piece);
    }

    public void ShowAvailableMoves_King(int initialCol, int initialFila, Piece piece)
    {
        ColorDePieza color = piece.color;

        for (int col = -1; col <= 1; col++) { for (int fila = -1; fila <= 1; fila++)
        {
            int col_newCell = initialCol + col;
            int fila_newCell = initialFila + fila;

            if (BoardAccess.ExceedTheBoard(col_newCell, fila_newCell) || (col == 0 && fila == 0)) continue;

            Cell cell = BoardAccess.GetCell(col_newCell, fila_newCell).GetComponent<Cell>();

            if (!Movement.IsCellEmpty(cell))
            {
                Movement.IsEnemyActivateRed(color, cell);
                break;
            }

            if (CellIsUnderAttack(cell)) continue;

            cell.ActivateBlueCell();
        }
        }
    }

    

    private bool CellIsUnderAttack(Cell cell)
    {
        throw new NotImplementedException();
    }
}

