using UnityEngine;


public class Poop : MonoBehaviour
{
    public float xVelocity; 
    
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
    }


    private void Start()
    {
        Destroy(gameObject, 2.5F);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (DidHitTarget<TargetController>(other.gameObject))
        {
            other.gameObject.GetComponent<TargetController>().Reveal();
            GameManager.Instance.PlayerScored();
            Destroy(gameObject);
        }
    }


    private static bool DidHitTarget<T>(GameObject go)
    {
        return go != null && go.CompareTag(Constants.TargetTag) && go.GetComponent<T>() != null;
    }
}

