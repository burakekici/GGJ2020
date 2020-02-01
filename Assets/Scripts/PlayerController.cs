using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // Properties
    public bool IsDead { get; private set; }

    // Fields
    public float yForce;
    
    private Rigidbody2D rb;
    private Animator animator;
    private PoopSpawner poopSpawner;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        poopSpawner = GetComponent<PoopSpawner>();
        rb.velocity = new Vector2(5F, 0F);
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
        }
    }


    #region Jump

    private void Jump()
    {
        var force = new Vector2(0F, yForce);
        rb.velocity = new Vector2(rb.velocity.x, 0F);
        rb.AddForce(force);
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

