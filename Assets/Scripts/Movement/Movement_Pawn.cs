using MovementInterfaces;
using System;

class Movement_Pawn :  IPawn
{
    public void ShowAvailableMoves(int initialCol, int initialFila, PieceBase piece)
    {
        ShowAvailableMoves_Pawn(initialCol, initialFila, piece);
    }
    public void ShowAvailableCaptures(int initialCol, int initialFila, PieceBase piece)
    {
        ShowAvailableCaptures_Pawn(initialCol, initialFila, piece);
    }

    public void ShowAvailableMoves_Pawn(int initialCol, int initialFila, PieceBase piece)
    {

        foreach (int movement in Movimientos(piece))
        {
            int fila_newCell = initialFila + movement;

            Cell cell = BoardAccess.GetCellGO(initialCol, fila_newCell).GetComponent<Cell>();

            if (fila_newCell != initialFila //para comprobar q no sean la misma pieza
                && cell.PieceOnThisCell != null) break;

            cell.ActivateBlueCell();
        }
    }
    private void OnPassant()
    {

    }

    private int[] Movimientos(PieceBase piece)
    {
        if (piece.colorDePieza == ColorDePieza.Negro && IsFirstMove(piece))
        {
            return new int[] { -1, -1 };
        }
        if (piece.colorDePieza == ColorDePieza.Negro && !IsFirstMove(piece))
        {
            return new int[] { -1 };
        }
        if (piece.colorDePieza == ColorDePieza.Blanco && IsFirstMove(piece))
        {
            return new int[] { 1, 1 };
        }
        else
        {
            return new int[] { 1 };
        }
    }

    private bool IsFirstMove(PieceBase piece)
    {
        return piece.fila == SecondRank(piece);
    }

    private int SecondRank(PieceBase piece)
    {
        return
            piece.colorDePieza == ColorDePieza.Negro
                ? 7
                : 2;
    }


    public void ShowAvailableCaptures_Pawn(int initialCol, int initialFila, PieceBase piece)
    {
        RegularCapture(initialCol, initialFila, piece);
        OnPassant();
    }

    private static void RegularCapture(int initialCol, int initialFila, PieceBase piece)
    {
        int filaAdder = piece.colorDePieza == ColorDePieza.Negro ? 1 : -1;

        foreach (int col in new int[] { 1, -1 })
        {
            Cell cell = BoardAccess.GetCellGO(initialCol + col, initialFila + filaAdder).GetComponent<Cell>();
            Movement.IsEnemyActivateRed(piece.colorDePieza, cell);
        }
    }



}