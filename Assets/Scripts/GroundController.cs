using UnityEngine;


public class GroundController : MonoBehaviour
{
    public Camera mainCamera;
    
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float length;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        length = boxCollider.size.x;
    }
    
    
    private void Update()
    {
        if (IsGroundOutOfSight())
        {
            RepositionAsNextGround();
        }
    }
    
    
    private bool IsGroundOutOfSight()
    {
        return mainCamera.transform.position.x - transform.position.x > length;
    }


    private void RepositionAsNextGround()
    {
        transform.position = new Vector3(mainCamera.transform.position.x + length - 0.25F, transform.position.y);
        GameManager.Instance.NextGroundPositioned(transform.position, boxCollider.size.x - 0.25F);
    }
}

