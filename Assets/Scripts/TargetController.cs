using UnityEngine;


public class TargetController : MonoBehaviour
{
    public GameObject deadTarget;
    public GameObject aliveTarget;

    private bool isRevealed;


    public void Reveal()
    {
        deadTarget.SetActive(false);
        aliveTarget.SetActive(true);
        isRevealed = true;
    }
}

