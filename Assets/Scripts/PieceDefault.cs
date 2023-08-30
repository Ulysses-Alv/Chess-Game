using UnityEngine;
using UnityEngine.UI;

public class PieceDefault : PieceBase
{
    [SerializeField]
    public PieceData pieceData;

    protected override void Start()
    {
        base.Start();
        PieceData pieceDataInstance = Instantiate(pieceData);
        colorDePieza = pieceDataInstance.colorDePieza;
        movement = pieceDataInstance.movement;
        GetComponent<Image>().sprite = pieceDataInstance.sprite;
        Invoke("Test_Piece", 1f);

        if (movement == null) Debug.LogError("NO EXISTE MOVEMENT");
    }
    private void Test_Piece()
    {
        print("columna: " + columna);
        print("fila: " + fila);
        celda.Value = BoardAccess.GetCellGO(columna, fila);
    }
}
