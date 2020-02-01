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
            transform.position = new Vector3(mainCamera.transform.position.x + length - 0.2F, transform.position.y);
        }
    }
    
    
    private bool IsGroundOutOfSight()
    {
        return mainCamera.transform.position.x - transform.position.x > length;
    }
}

