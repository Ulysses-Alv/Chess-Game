using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Coords coords;
    public GameObject PieceOnThisCell;
    public GameObject checkDot;
    public int col;
    public int fila;

    [SerializeField] private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetCell(int Columna, int Fila, Color color)
    {
        coords = new Coords(Columna, Fila);
        
        col = Columna;
        fila = Fila;
        GetComponent<Image>().color = color;
    }

    public void SetPiece(Piece piece)
    {
        if (PieceOnThisCell != null) Destroy(PieceOnThisCell);

        PieceOnThisCell = piece.gameObject;
    }
    public void ShowPieceOnThisCellAvailableMovements()
    {
        if (PieceOnThisCell == null) return;

        Piece piece = PieceOnThisCell.GetComponent<Piece>();

        piece.ShowPieceAvailableMovements();
    }
    
    public void ActivateBlueCell()
    {
        checkDot.SetActive(true);
        checkDot.GetComponent<Image>().color = Color.blue;
        Invoke("DeactivateBlue", 2f);
    }
    private void AddMoveToThisCell()
    {
        button.onClick.AddListener(MoveToThisCell);
    }
    private void MoveToThisCell()
    {

    }
    void DeactivateBlue()
    {
        button.onClick.RemoveListener(ActivateBlueCell);
        checkDot.SetActive(false);
        checkDot.GetComponent<Image>().color = Color.green;
    }
    void DeactivateRed()
    {

        button.onClick.RemoveListener(ActivateRed);
        checkDot.SetActive(false);
        checkDot.GetComponent<Image>().color = Color.green;
    }
    public void ActivateRed()
    {
        checkDot.SetActive(true);
        checkDot.GetComponent<Image>().color = Color.green;
        Invoke("DeactivateRed", 2f);
    }
}
