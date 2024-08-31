
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
        GameObject squares = new GameObject(squaresParentName);
        squares.transform.SetParent(this.transform);

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject square = Instantiate(squarePrefab, new Vector3(x, y, 0), Quaternion.identity);
                square.transform.SetParent(squares.transform);
            }
        }
    }
}
