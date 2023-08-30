using UnityEngine;
using UnityEngine.UI;
using MovementInterfaces;

public class PieceCustom : PieceBase
{
    public void SetPieceInformation(ColorDePieza color, IMovement movement, GameObject celda, int columna, int fila)
    {
        this.colorDePieza = color;
        this.movement = movement;
        this.celda.Value = celda;
        this.columna = columna;
        this.fila = fila;
    }
}
