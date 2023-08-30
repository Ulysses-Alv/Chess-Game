using MovementInterfaces;
using System;
using UnityEngine;

public class Movement_Queen :  IMovement
{
    public void ShowAvailableCaptures(int initialCol, int initialFila, PieceBase piece)
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableMoves(int initialCol, int initialFila, PieceBase piece)
    // initial = posicion donde se encuentra la pieza.
    // final = posicion a la que irá la pieza.
    {
        var bishop = new Movement_Bishop();
        bishop.ShowAvailableMoves_Bishop(initialCol, initialFila, piece);

        var rook = new Movement_Rook();
        rook.ShowAvailableMoves_Rook(initialCol, initialFila, piece);
    }


}
