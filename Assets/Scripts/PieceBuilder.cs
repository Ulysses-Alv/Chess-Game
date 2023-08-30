using MovementInterfaces;
using UnityEngine;
using Object = UnityEngine.Object;

public class PieceBuilder
{
    private PieceCustom piece;
    private IMovement movement;
    private ColorDePieza colorDePieza;
    private Sprite sprite;
    private int col;
    private int fila;
    private Transform position;

    public PieceBuilder WithMovement(IMovement movement)
    {
        this.movement = movement;
        return this;
    }

    public PieceBuilder WithImage(Sprite sprite)
    {
        this.sprite = sprite;
        return this;
    }

    public PieceBuilder WithPosition(int col, int fila)
    {
        this.col = col;
        this.fila = fila;
        position = BoardAccess.GetCellPosition(col, fila);
        
        return this;
    }
    public PieceBuilder WithColor(ColorDePieza colorDePieza)
    {
        this.colorDePieza = colorDePieza;
        return this;
    }

    public PieceCustom Build() //Esto Instancia el objeto, en este caso la pieza
    {
        PieceCustom _piece = Object.Instantiate(piece, position);
        var cell = BoardAccess.GetCellGO(col, fila);

        cell.GetComponent<Cell>().SetPiece(piece);
        return _piece;
    }
}