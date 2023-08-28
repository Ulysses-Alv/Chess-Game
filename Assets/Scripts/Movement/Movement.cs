public class Movement
{

    protected static bool ExceedTheBoard(int col_newCell, int fila_newCell)
    {
        return col_newCell < 1 || col_newCell > 8 || fila_newCell < 1 || fila_newCell > 8;
    }




}
