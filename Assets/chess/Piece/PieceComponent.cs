using UnityEngine;

[ExecuteAlways]
public class PieceComponent : MonoBehaviour
{
    [SerializeField]
    public PieceType pieceType;

    [SerializeField]
    public PieceColor pieceColor;

    private void Start()
    {
        InitializeIcon();
    }

    private void OnValidate()
    {
        InitializeIcon();
    }

    public void InitializeIcon()
    {
        string resourceName = pieceType.ToString().ToLower();
        Sprite sprite = Resources.Load<Sprite>(resourceName);

        var spriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.color = pieceColor == PieceColor.White ? Color.cyan : Color.magenta;
    }
}
