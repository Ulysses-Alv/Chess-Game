using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MovementInterfaces
{
    public interface IMovement
    {
        void ShowAvailableMoves(int initialCol, int initialFila, PieceBase piece);
    }
    public interface IBishop : IMovement
    {
        public void ShowAvailableMoves_Bishop(int initialCol, int initialFila, PieceBase piece);

    }

    public interface IKing : IMovement
    {
        public void ShowAvailableMoves_King(int initialCol, int initialFila, PieceBase piece);

    }
    public interface IRook : IMovement
    {

        public void ShowAvailableMoves_Rook(int initialCol, int initialFila, PieceBase piece);
    }
    public interface IPawn : IMovement
    {

        public void ShowAvailableMoves_Pawn(int initialCol, int initialFila, PieceBase piece);
    }

    public interface IKnight : IMovement
    {

        public void ShowAvailableMoves_Knight(int initialCol, int initialFila, PieceBase piece);
    }
}
