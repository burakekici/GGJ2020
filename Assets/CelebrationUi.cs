using DG.Tweening;
using TMPro;
using UnityEngine;


public class CelebrationUi : MonoBehaviour
{
    private TextMeshProUGUI celebrationText;
    private Vector3 initialPosition;
    private CanvasGroup canvasGroup;
    
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        celebrationText = GetComponentInChildren<TextMeshProUGUI>();
        
        //initialPosition = transform.position;
        //transform.position = new Vector3(initialPosition.x, initialPosition.y + 500F * transform.root.localScale.y);
        celebrationText.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0F;
    }


    public void Initialize()
    {
        SetCelebrationText();

        canvasGroup.DOFade(1F, 0.25F);
        //transform.DOLocalMove(initialPosition, 0.6F).SetEase(Ease.InSine);
        celebrationText.transform.DOScale(Vector3.one * 1.1F, 0.5F).SetEase(Ease.InSine).OnComplete(() =>
        {
            celebrationText.transform.DOScale(Vector3.one, 0.1F).SetEase(Ease.InSine);
            canvasGroup.DOFade(0F, 0.25F).SetDelay(0.1F).OnComplete(() => { Destroy(gameObject); });
        });
    }


    private void SetCelebrationText()
    {
        celebrationText.text = GetRandomCelebrationText();
    }


    private static string GetRandomCelebrationText()
    {
        var number = Random.Range(0, 6);

        switch (number)
        {
            case 0:
                return "Poop master!!";
            case 1:
                return "Great shit!";
            case 2:
                return "Keep going!";
            case 3:
                return "That ass has a turbo";
            case 4:
                return "Perfect!";
            case 5:
                return "Oh, shit!!";
        }

        return "Amazing!";
    }
}

