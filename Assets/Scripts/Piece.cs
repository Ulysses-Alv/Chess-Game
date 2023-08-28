using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public readonly ReactiveProperty<GameObject> celda = new ReactiveProperty<GameObject>(initialValue: null);

    [SerializeField] private GameObject old_cell = null;


    public Movement movement;

    public readonly ColorDePieza color;

    [Range(1, 8)]
    public int columna;
    [Range(1, 8)]
    public int fila;
    private TipoDePieza tipoDePieza;

    [SerializeField]
    private PieceSprites white_sprites;

    [SerializeField]
    private PieceSprites black_sprites;

    void Awake()
    {
        SetPieceInformation();
    }
    private void Start()
    {
        celda.Subscribe(SetPosition);
        Invoke("Test_Piece", .5f);
    }
    private void Test_Piece()
    {
        celda.Value = Board.GetCell(columna, fila);
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

    private void SetPieceInformation()
    {
        movement = PieceConfig.GetMovement(tipoDePieza);
        SetSprite();
    }

    private void SetSprite()
    {
        Image image = GetComponent<Image>();
        PieceSprites sprites = SetColorOfPiece();

        switch (tipoDePieza)
        {
            case TipoDePieza.Queen:
                image.sprite = sprites.Queen;
                break;
            case TipoDePieza.Pawn:
                image.sprite = sprites.Pawn;
                break;
            case TipoDePieza.Rook:
                image.sprite = sprites.Rook;
                break;
            case TipoDePieza.Knight:
                image.sprite = sprites.Knight;
                break;
            case TipoDePieza.Bishop:
                image.sprite = sprites.Bishop;
                break;
            case TipoDePieza.King:
                image.sprite = sprites.King;
                break;
            case TipoDePieza.Custom:
                break;
            default:
                Debug.LogError("Invalid piece type");
                break;
        }
    }

    private PieceSprites SetColorOfPiece()
    {
        return
            color == ColorDePieza.Negro
                ? black_sprites
                    : white_sprites;
    }

    public void ShowPieceAvailableMovements()
    {
        movement.ShowAvailableMoves(columna, fila, this);
    }
    public void GetActualCell()
    {
        celda.Value = Board.GetCell(columna, fila);
    }
}

enum TipoDePieza
{
    Queen,King,Bishop,Rook,Knight,Pawn,Custom
}