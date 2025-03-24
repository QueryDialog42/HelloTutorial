using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject blackBackgroundObject;
    [SerializeField] private GameObject winPopUp;
    [SerializeField] private GameObject losePopUp;

    [Header("Settings")]
    [SerializeField] private float animationDuration = 0.3f;

    private Image blackBackgroundImage;
    private RectTransform winPopUpTransform;
    private RectTransform losePopUpTransform;

    void Awake()
    {
        blackBackgroundImage = blackBackgroundObject.GetComponent<Image>();
        winPopUpTransform = winPopUp.GetComponent<RectTransform>();
        losePopUpTransform = losePopUp.GetComponent<RectTransform>();
    }

    public void OnGameWin(){
        blackBackgroundObject.SetActive(true);
        winPopUp.SetActive(true);
        blackBackgroundImage.DOFade(0.8f, animationDuration).SetEase(Ease.Linear);
        winPopUpTransform.DOScale(1.5f, animationDuration).SetEase(Ease.OutBack);
    }

    public void OnGameLose(){
        blackBackgroundObject.SetActive(true);
        losePopUp.SetActive(true);
        blackBackgroundImage.DOFade(0.8f, animationDuration).SetEase(Ease.Linear);
        losePopUpTransform.DOScale(1.5f, animationDuration).SetEase(Ease.OutBack);
    }
}
