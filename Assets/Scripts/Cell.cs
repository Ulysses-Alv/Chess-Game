using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Coords coords;
    public GameObject PieceOnThisCell;
    public int col;
    public int fila;
    public GameObject checkDot;

    public void SetCell(int Columna, int Fila, Color color)
    {
        coords = new Coords(Columna, Fila);
        
        col = Columna;
        fila = Fila;
        GetComponent<Image>().color = color;
    }

    public void ShowPieceOnThisCellAvailableMovements()
    {
        if (PieceOnThisCell == null) return;

        Piece piece = PieceOnThisCell.GetComponent<Piece>();

        piece.ShowPieceAvailableMovements();
    }
    public void ActivateRed()
    {
        checkDot.SetActive(true);
        checkDot.GetComponent<Image>().color = Color.green;
        Invoke("Deactivate", 2f);
    }
    public void ActivateBlueCell()
    {
        checkDot.SetActive(true);
        checkDot.GetComponent<Image>().color = Color.blue;
        Invoke("Deactivate", 2f);
    }
    void Deactivate()
    {
        checkDot.SetActive(false);
        checkDot.GetComponent<Image>().color = Color.green;
    }
}
