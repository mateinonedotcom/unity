using UnityEngine;

[ExecuteAlways]
public class SquareComponent : MonoBehaviour
{
    [SerializeField]
    public Rank rank;

    [SerializeField]
    public File file;

    void Start()
    {
        SetBackgroundColor();
    }

    void SetBackgroundColor()
    {
        bool odd = ((int)rank + (int)file) % 2 == 0;
        Color color = odd ? Color.black : Color.white;

        transform
            .Find("Background")
            .GetComponent<SpriteRenderer>()
            .color = color;
    }
}
