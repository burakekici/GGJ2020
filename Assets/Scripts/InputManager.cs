using UnityEngine;


public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance.IsDead)
            {
                GameManager.ReloadScene();
            }
            GameManager.Instance.Flap();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.Poop();
        }
    }
}

