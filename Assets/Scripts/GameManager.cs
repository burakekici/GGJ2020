using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public UiController uiController;
    public PlayerController playerController;
    
    public bool IsDead {get; private set; }
    public int poopsMax;

    private int poopsLeft;
    private int score;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Initialize()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;

        score = 0;
        poopsLeft = poopsMax;
        uiController.UpdateScoreText(score);
        uiController.UpdateMagazineText(poopsLeft,poopsMax);
    }


    public static void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


    #region Inputs

    public void Flap()
    {
        if (IsDead)
        {
            return;
        }
        playerController.Flap();
    }


    public void Poop()
    {
        if (IsDead || poopsLeft == 0)
        {
            return;
        }
        playerController.Poop();
    }

    #endregion
    

    #region Progression

    public void PlayerScored()
    {
        score++;
        uiController.UpdateScoreText(score);
        uiController.Celebrate();
        KyVibrator.Vibrate(40);
        if (poopsLeft < poopsMax)
        {
            poopsLeft++;
        }
    }


    public void PlayerPooped()
    {
        poopsLeft--;
        uiController.UpdateMagazineText(poopsLeft, poopsMax);

        if (poopsLeft == 0)
        {
            PlayerDied();
        }
    }
    
    
    public void PlayerDied()
    {
        Printer.PrintRed("Player hit to GROUND.");
        IsDead = true;
        
        UpdateHighScore(score);
        uiController.ShowGameEndCanvas(score, GetHighScore());
    }
    
    #endregion


    #region High score

    private static void UpdateHighScore(int score)
    {
        var highScore = PlayerPrefs.GetInt(Constants.HighScoreKey, 0);
        
        if (score > highScore)
        {
            PlayerPrefs.SetInt(Constants.HighScoreKey, score);
        }
    }


    private static int GetHighScore()
    {
        return PlayerPrefs.GetInt(Constants.HighScoreKey, 0);
    }

    #endregion


    #region Events

    public delegate void OnNextGroundPositioned(Vector3 groundPosition, float groundWidth);
    public event OnNextGroundPositioned NotifyOnNextGroundPositionedObservers;


    public void NextGroundPositioned(Vector3 groundPosition, float groundWidth)
    {
        NotifyOnNextGroundPositionedObservers?.Invoke(groundPosition, groundWidth);
    }

    #endregion
}

