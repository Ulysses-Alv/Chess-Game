public struct Coords
{
    public int Columna;
    public int Fila;
    
    public Coords(int x, int y)
    {
        Columna = x;
        Fila = y;
    }

    public (int, int) GetPosition()
    {
        return (Columna, Fila);
    }
}
