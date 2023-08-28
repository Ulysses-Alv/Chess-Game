using UnityEngine;
using Object = UnityEngine.Object;

public class PieceBuilder
{
    [SerializeField] private Piece piece;
    private Movement movement;
    private ColorDePieza colorDePieza;
    private Sprite sprite;
    private Coords coords;

    public PieceBuilder WithMovement(Movement movement)
    {
        this.movement = movement;
        return this;
    }

    public PieceBuilder WithImage(Sprite sprite)
    {
        this.sprite = sprite;
        return this;
    }

    public PieceBuilder WithPosition(Coords coords)
    {
        this.coords = coords;
        return this;
    }
    public PieceBuilder WithColor(ColorDePieza colorDePieza)
    {
        this.colorDePieza = colorDePieza;
        return this;
    }

    public Piece Build() //Esto Instancia el objeto, en este caso la pieza
    {
        Piece piece = Object.Instantiate(this.piece);

        return piece;
    }
}