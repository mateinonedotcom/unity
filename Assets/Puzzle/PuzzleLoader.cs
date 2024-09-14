using UnityEngine;
using UnityRandom = UnityEngine.Random;

class PuzzleLoader
{
    private TextAsset textAsset;

    private static PuzzleLoader instance;
    public static PuzzleLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PuzzleLoader();
                instance.textAsset = Resources.Load<TextAsset>("checkmate-lichess-2013-01");
            }

            return instance;
        }
    }

    public Puzzle Random()
    {
        var lines = textAsset.text.Split('\n');

        var rndLineIndex = UnityRandom.Range(0, lines.Length);
        var rndLine = lines[rndLineIndex];

        rndLine = rndLine.Replace("pieceSquares", "PieceSquares");
        rndLine = rndLine.Replace("turn", "Turn");
        rndLine = rndLine.Replace("validMoves", "ValidMoves");
        rndLine = rndLine.Replace("checkmateMoves", "CheckmateMoves");
        rndLine = rndLine.Replace("piece", "Piece");
        rndLine = rndLine.Replace("square", "Square");
        rndLine = rndLine.Replace("from", "From");
        rndLine = rndLine.Replace("to", "To");

        var puzzle = JsonUtility.FromJson<Puzzle>(rndLine);

        return puzzle;
    }
}
