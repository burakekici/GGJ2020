using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float yForce;
    
    private Rigidbody2D rigidBody;
    private Animator animator;
    private PoopSpawner poopSpawner;
    
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        poopSpawner = GetComponentInChildren<PoopSpawner>();
        rigidBody.velocity = new Vector2(5F, 0F);
    }
    

    #region Flap

    public void Flap()
    {
        var force = new Vector2(0F, yForce);
        rigidBody.velocity = new Vector2(5F, 0F); //(rb.velocity.x, 0F);
        rigidBody.AddForce(force);
        animator.SetTrigger("fly");
    }
    
    #endregion


    #region Flap
    
    public void Poop()
    {
        animator.SetTrigger("poop");
        poopSpawner.ThrowPoop();
        rigidBody.velocity = new Vector2(5F, rigidBody.velocity.y);
        GameManager.Instance.PlayerPooped();
    }    

    #endregion
    

    #region Collision

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (DidHitObstacle(other.gameObject))
        {
            GameManager.Instance.PlayerDied();
            animator.SetTrigger("die");
        }
    }


    private static bool DidHitObstacle(GameObject go)
    {
        return go.CompareTag(Constants.GroundTag) || go.CompareTag(Constants.ObstacleTag);
    }
    
    #endregion
}

