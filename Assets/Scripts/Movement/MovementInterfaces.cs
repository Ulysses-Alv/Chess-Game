namespace MovementInterfaces
{
    public interface IMovement
    {
        void ShowAvailableMoves(int initialCol, int initialFila, Piece piece);
    }
    public interface IBishop : IMovement
    {
        public void ShowAvailableMoves_Bishop(int initialCol, int initialFila, Piece piece);

    }

    public interface IKing : IMovement
    {
        public void ShowAvailableMoves_King(int initialCol, int initialFila, Piece piece);

    }
    public interface IRook : IMovement
    {

        public void ShowAvailableMoves_Rook(int initialCol, int initialFila, Piece piece);
    }
    public interface IPawn : IMovement
    {

        public void ShowAvailableMoves_Pawn(int initialCol, int initialFila, Piece piece);
    }

    public interface IKnight : IMovement
    {

        public void ShowAvailableMoves_Knight(int initialCol, int initialFila, Piece piece);
    }
}
