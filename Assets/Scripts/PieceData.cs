using MovementInterfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "PiezaDeAjedrez", menuName = "Ajedrez/Pieza")]
[System.Serializable]
public class PieceData : ScriptableObject
{
    public TipoDePieza tipoDePieza;
    public ColorDePieza colorDePieza;
    public IMovement movement;
    public Sprite sprite;

    private void Awake()
    {
        switch (tipoDePieza)
        {
            case TipoDePieza.Queen: movement = new Movement_Queen(); break;
            case TipoDePieza.King: movement = new Movement_King(); break;
            case TipoDePieza.Knight: movement = new Movement_Knight(); break;
            case TipoDePieza.Pawn: movement = new Movement_Pawn(); break;
            case TipoDePieza.Bishop: movement = new Movement_Bishop(); break;
            case TipoDePieza.Rook: movement = new Movement_Rook(); break;
                default : break;
        }
    }
}