using UnityEngine;


public class TargetController : MonoBehaviour
{
    private Animator animator;
    public bool IsRevealed { get; private set; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void Reveal()
    {
        animator.SetTrigger("reveal");
        IsRevealed = true;
    }
}

