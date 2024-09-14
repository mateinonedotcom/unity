using System;
using UnityEngine;

[Serializable]
public class Puzzle
{
    public PieceSquare[] PieceSquares;
    public string Turn;
    public Move[] ValidMoves;
    public Move[] CheckmateMoves;
}

[Serializable]
public class PieceSquare
{
    public Piece Piece;
    public Square Square;
}

[Serializable]
public class Piece
{
    public string type;
    public PieceType Type => Enum.Parse<PieceType>(type);

    public string color;
    public PieceColor Color => Enum.Parse<PieceColor>(color);
}

[Serializable]
public class Square
{
    public string file;
    public File File => Enum.Parse<File>(file.ToUpper());

    public string rank;
    public Rank Rank => rank switch
    {
        "1" => Rank.One,
        "2" => Rank.Two,
        "3" => Rank.Three,
        "4" => Rank.Four,
        "5" => Rank.Five,
        "6" => Rank.Six,
        "7" => Rank.Seven,
        "8" => Rank.Eight,
        _ => throw new ArgumentException("Invalid rank")
    };
}

[Serializable]
public class Move
{
    public Square From;
    public Square To;
}
