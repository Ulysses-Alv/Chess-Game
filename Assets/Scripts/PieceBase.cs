using UnityEngine;
using UniRx;
using System;
using MovementInterfaces;

public abstract class PieceBase : MonoBehaviour
{
    public ReactiveProperty<GameObject> celda = new ReactiveProperty<GameObject>(initialValue: null);
    public ColorDePieza colorDePieza;

    [Range(1, 8)]
    public int columna;
    [Range(1, 8)]
    public int fila;

    public IMovement movement;
    public bool CanJump;
    protected GameObject old_cell = null;
    public void GetActualCell()
    {
        celda.Value = BoardAccess.GetCellGO(columna, fila);
    }

    public void ShowPieceAvailableMovements()
    {
        if (movement == null)
        {
            Debug.LogError("NO EXISTE MOVEMENT"); 
            return;
        }
        movement.ShowAvailableMoves(columna, fila, this);
    }

    protected void SetPosition(GameObject obj)
    {
        if (obj == null) return;

        if (old_cell != null)
            old_cell.GetComponent<Cell>().PieceOnThisCell = null;

        transform.position = obj.transform.position;

        Cell celda = obj.GetComponent<Cell>();
        celda.PieceOnThisCell = gameObject;

        (int x, int y) = celda.coords.GetPosition();

        columna = x;
        fila = y;
    }

    protected virtual void Start()
    {
        celda.Subscribe(SetPosition);
    }

}
