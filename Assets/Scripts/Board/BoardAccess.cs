using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoardGenerator))]
public class BoardAccess : MonoBehaviour
{
    public static List<GameObject> _cells => BoardGenerator._cells;
    
    public static bool ExceedTheBoard(int col, int fila)
    {
        return (col > 8 || fila > 8 || col < 0 || fila < 0);
    }
    public static GameObject GetCellGO(int col, int fila)
    {
        foreach (GameObject cell in _cells)
        {
            (int columna, int fila) coordenadas = cell.GetComponent<Cell>().coords.GetPosition();

            if (coordenadas.fila == fila && coordenadas.columna == col)
                return cell;
        }
        Debug.LogError("No se encontró una Celda que coincida con esa posicion");
        return null;
    }
    public static Transform GetCellPosition(int col, int fila)
    {
        return GetCellGO(col, fila).gameObject.transform;
    }

}
