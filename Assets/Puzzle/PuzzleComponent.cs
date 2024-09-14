using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComponent : MonoBehaviour
{
    [SerializeField]
    public BoardComponent board;

    [SerializeField]
    public GameObject piecePrefab;

    private Puzzle puzzle;

    void Start()
    {
        puzzle = PuzzleLoader.Instance.Random();
        InitializePuzzle();
    }

    void InitializePuzzle()
    {
        foreach (var pieceSquare in puzzle.PieceSquares)
        {
            var piece = Instantiate(piecePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            var pieceComponent = piece.GetComponent<PieceComponent>();
            pieceComponent.pieceType = pieceSquare.Piece.Type;
            pieceComponent.pieceColor = pieceSquare.Piece.Color;
            pieceComponent.InitializeIcon();

            var squareComponent = board.GetSquare(pieceSquare.Square.File, pieceSquare.Square.Rank);
            piece.transform.SetParent(squareComponent.transform, false);

            Debug.Log("Piece: " + pieceSquare.Piece.Type + " " + pieceSquare.Piece.Color + " " + pieceSquare.Square.File + " " + pieceSquare.Square.Rank);
            Debug.Log("Square: " + squareComponent.file + " " + squareComponent.rank);

            // var square = board.GetSquare(pieceSquare.Square.File, pieceSquare.Square.Rank);
            // square.SetPiece(piece);
        }
    }
}
