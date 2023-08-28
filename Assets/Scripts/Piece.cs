using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using MovementInterfaces;

public class Piece : MonoBehaviour
{
    [SerializeField] private GameObject old_cell = null;
    [SerializeField] private TipoDePieza tipoDePieza;
    
    public ReactiveProperty<GameObject> celda = new ReactiveProperty<GameObject>(initialValue: null);
    public IMovement movement;
    public ColorDePieza color;

    [Range(1, 8)]
    public int columna;
    [Range(1, 8)]
    public int fila;
        
    private void Start()
    {
        //celda.Subscribe(SetPosition);
        //Invoke("Test_Piece", .5f);
    }
    private void Test_Piece()
    {
        celda.Value = BoardAccess.GetCell(columna, fila);
    }

    private void SetPosition(GameObject obj)
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

    public void SetPieceInformation(ColorDePieza color, IMovement movement, GameObject celda, int columna, int fila)
    {
        this.color = color;
        this.movement = movement;
        this.celda.Value = celda;
        this.columna = columna;
        this.fila = fila;
    }   
    
    public void ShowPieceAvailableMovements()
    {
        movement.ShowAvailableMoves(columna, fila, this);
    }
    public void GetActualCell()
    {
        celda.Value = BoardAccess.GetCell(columna, fila);
    }
}
