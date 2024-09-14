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
        SetIcon();
    }

    private void OnValidate()
    {
        SetIcon();
    }

    void SetIcon()
    {
        string resourceName = pieceType.ToString().ToLower();
        Sprite sprite = Resources.Load<Sprite>(resourceName);

        var spriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.color = pieceColor == PieceColor.White ? Color.white : Color.black;
    }
}
