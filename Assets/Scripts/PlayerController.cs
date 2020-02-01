using UnityEngine;
using UnityEngine.SceneManagement;


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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsDead)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !IsDead)
        {
            poopSpawner.ThrowPoop();
            rigidBody.velocity = new Vector2(5F, rigidBody.velocity.y);
        }
    }


    #region Jump

    private void Jump()
    {
        var force = new Vector2(0F, yForce);
        rigidBody.velocity = new Vector2(5F, 0F); //(rb.velocity.x, 0F);
        rigidBody.AddForce(force);
        animator.SetTrigger("fly");
    }
    
    #endregion
    

    #region Collision

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Constants.GroundTag))
        {
            Printer.PrintRed("Player hit to GROUND.");
            IsDead = true;
            animator.SetTrigger("die");
        }
    }
    
    #endregion
}

