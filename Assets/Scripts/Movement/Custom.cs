using MovementInterfaces;
using System;

public class Custom : IMovement, IKing, IKnight, IPawn, IRook, IBishop
{
    public Action<int, int,Piece> showAvailableMoves;

    public void ShowAvailableCaptures(int initialCol, int initialFila, Piece piece)
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableMoves(int initialCol, int initialFila, Piece piece)
    {
        showAvailableMoves += ShowAvailableMoves_King;
    }
    public void ShowAvailableMoves_Bishop(int initialCol, int initialFila, Piece piece)
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableMoves_King(int initialCol, int initialFila, Piece piece)
    {
        var king = new Movement_King();
        king.ShowAvailableMoves(initialCol, initialFila, piece);
    }

    public void ShowAvailableMoves_Knight(int initialCol, int initialFila, Piece piece)
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableMoves_Pawn(int initialCol, int initialFila, Piece piece)
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableMoves_Rook(int initialCol, int initialFila, Piece piece)
    {
        throw new NotImplementedException();
    }
}