using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
    [Header("Game Play")]
    public Text scoreText;
    public Text magazineText;
    [Header("Game End")]
    public Canvas gameEndCanvas;
    public Text gameEndScoreText;
    public Text gameEndHighestScoreText;
    [Header("Celebration")] 
    public GameObject celebrationPrefab;


    private void Start()
    {
        gameEndCanvas.gameObject.SetActive(false);
    }


    #region Text updating
    
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }


    public void UpdateMagazineText(int poopsLeft, int poopsMax)
    {
        magazineText.text = "Poops: " + poopsLeft + " / " + poopsMax;
    }

    #endregion


    #region Button taps
    
    public void FlapButtonTapped()
    {
        GameManager.Instance.Flap();
    }


    public void PoopButtonTapped()
    {
        GameManager.Instance.Poop();
    }


    public void PlayButtonTapped()
    {
        GameManager.ReloadScene();
    }
    
    #endregion
    
    
    #region Game end canvas

    public void ShowGameEndCanvas(int score, int highestScore)
    {
        gameEndCanvas.gameObject.SetActive(true);
        gameEndScoreText.text = "Your Score: " + score;
        gameEndHighestScoreText.text = "Highest Score: " + highestScore;
    }
    
    #endregion


    #region Celebration

    public void Celebrate()
    {
        var controller = Instantiate(celebrationPrefab, transform).GetComponent<CelebrationUi>();
        controller.Initialize();
    }

    #endregion
}

