public static class Movement
{
    public static bool ExceedTheBoard(int col_newCell, int fila_newCell)
    {
        return col_newCell < 1 || col_newCell > 8 || fila_newCell < 1 || fila_newCell > 8;
    }
    public static void IsEnemyActivateRed(ColorDePieza color, Cell cell)
    {
        if (IsEnemyPiece(color, cell)) cell.ActivateRed();
    }

    public static bool IsEnemyPiece(ColorDePieza color, Cell cell)
    {
        return cell.PieceOnThisCell.GetComponent<Piece>().color != color;
    }

    public static bool IsCellEmpty(Cell cell)
    {
        return cell.PieceOnThisCell != null;
    }



}
