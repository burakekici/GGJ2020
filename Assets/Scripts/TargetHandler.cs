using UnityEngine;


public class TargetHandler : MonoBehaviour
{
    public Sprite revealSprite;

    private SpriteRenderer spriteRenderer;
    private bool isRevealed;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void ChangeSprite()
    {
        spriteRenderer.sprite = revealSprite;
    }
}    

