using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
    public Text scoreText;


    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
    
    
    public void FlapButtonTapped()
    {
        
    }


    public void PoopButtonTapped()
    {
        
    }
}

