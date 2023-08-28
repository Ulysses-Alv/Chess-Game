using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject Cell;
    public static Board instance;

    public List<GameObject> cells;
    public static List<GameObject> _cells;

    public GridSystem gridSystem;
    private void Awake()
    {
        instance = this;
        _cells = instance.cells;
    }
    void Start()
    {
        for (float x_col = 0; x_col < (width / 2); x_col += .5f)
        {
            for (float y_fila = 0; y_fila < (height / 2); y_fila += .5f)
            {
                CreateNewCell(y_fila, x_col);
            }
        }
    }
    public static GameObject GetCell(int col, int fila)
    {
        foreach (GameObject cell in _cells)
        {
            
            (int columna, int fila) coordenadas = cell.GetComponent<Cell>().coords.GetPosition();

            if (coordenadas.fila == fila && coordenadas.columna == col)
                return cell;
        }
        return null;
    }

    #region Creacion
    private void CreateNewCell(float x, float y)
    {
        GameObject newCell = NewCell(x, y);
        cells.Add(newCell);
    }

    private GameObject NewCell(float x, float y)
    {
        Vector3 position = gridSystem.GetNearestPointOnGrid(new Vector3(x, y, 0f));
        GameObject newCell = Instantiate(Cell, position, Quaternion.identity, this.transform);
        var c = Mathf.FloorToInt(x * 2) + 1;
        var f = Mathf.FloorToInt(y * 2) + 1;
        newCell.GetComponent<Cell>().SetCell(c, f, SetColor(x, y));

        return (newCell);
    }

    private Color SetColor(float fila, float columna)
    {
        var f = fila * 2;
        var c = columna * 2;


        if (f % 2 == 0)
        {
            if (c % 2 == 0)
            {
                return Color.black;
            }
            else
            {
                return Color.white;
            }
        }
        else
        {
            if (c % 2 == 0)
            {
                return Color.white;
            }
            else
            {
                return Color.black;
            }
        }
    }
    #endregion

}
