using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public UiController uiController;
    
    private int score;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        score = 0;
    }


    public void PlayerScored()
    {
        score++;
        uiController.UpdateScoreText(score);
    }


    #region Events

    public delegate void OnNextGroundPositioned(Vector3 groundPosition, float groundWidth);
    public event OnNextGroundPositioned NotifyOnNextGroundPositionedObservers;


    public void NextGroundPositioned(Vector3 groundPosition, float groundWidth)
    {
        NotifyOnNextGroundPositionedObservers?.Invoke(groundPosition, groundWidth);
    }

    #endregion
}

