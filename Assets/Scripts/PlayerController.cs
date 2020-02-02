using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Properties
    public bool IsDead { get; private set; }

    // Fields
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
        poopSpawner.ThrowPoop();
        rigidBody.velocity = new Vector2(5F, rigidBody.velocity.y);
        GameManager.Instance.PlayerPooped();
    }    

    #endregion
    

    #region Collision

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Constants.GroundTag))
        {
            GameManager.Instance.PlayerDied();
            animator.SetTrigger("die");
        }
    }
    
    #endregion
}

