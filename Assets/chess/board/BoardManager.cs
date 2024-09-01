
using UnityEngine;

[ExecuteAlways]
public class BoardComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;

    void Start()
    {
        DestroySquares();
        InitializeSquares();
    }

    private string squaresParentName = "Squares";

    void DestroySquares()
    {
        foreach (Transform child in transform)
        {
            if (child.name == squaresParentName)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    void InitializeSquares()
    {
        float offset = 3.5f;

        GameObject squares = new GameObject(squaresParentName);
        squares.transform.SetParent(this.transform);

        for (int x = 0; x < 8; x++)
        {
            Rank rank = (Rank)x;
            for (int y = 0; y < 8; y++)
            {
                File file = (File)y;

                Vector3 position = new Vector3((int)rank - offset, (int)file - offset, 0);

                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity);
                square.transform.SetParent(squares.transform);

                SquareComponent squareComponent = square.GetComponent<SquareComponent>();
                squareComponent.rank = rank;
                squareComponent.file = file;
            }
        }
    }
}
