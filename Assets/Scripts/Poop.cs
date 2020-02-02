using UnityEngine;


public class Poop : MonoBehaviour
{
    public float xVelocity; 
    
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private ParticleSystem particleEmitter;


    private void Awake()
    {
        particleEmitter = GetComponentInChildren<ParticleSystem>();
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
        if (DidHitSomething(other.gameObject))
        {
            particleEmitter.Stop();
        }
        
        if (!DidHitTarget<TargetController>(other.gameObject))
        {
            return;
        }
        
        var targetController = other.gameObject.GetComponent<TargetController>();
        if (targetController.IsRevealed)
        {
            return;
        }
            
        targetController.Reveal();
        GameManager.Instance.PlayerScored();
        Destroy(gameObject);
    }


    private static bool DidHitSomething(GameObject go)
    {
        return go != null &&
               (go.CompareTag(Constants.TargetTag) || 
                go.CompareTag(Constants.GroundTag) ||
                go.CompareTag(Constants.ObstacleTag));
    }


    private static bool DidHitTarget<T>(GameObject go)
    {
        return go != null && go.CompareTag(Constants.TargetTag) && go.GetComponent<T>() != null;
    }
}

