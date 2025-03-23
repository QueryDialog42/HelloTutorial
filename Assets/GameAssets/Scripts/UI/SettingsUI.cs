using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject settingsPopUpObject;
    [SerializeField] private GameObject blackBackgroundObject;
    [Header("Buttons")]
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    [Header("Setting Animation Settings")]
    [SerializeField] private float animationDuration;

    private Image blackBackgroundImage;

    private void Awake()
    {
        blackBackgroundImage = blackBackgroundObject.GetComponent<Image>();
        settingsPopUpObject.transform.localScale = Vector3.zero;
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        resumeButton.onClick.AddListener(ResumeButtonClicked);
    }

    private void OnSettingsButtonClicked(){
        GameManager.Instance.ChangeGameState(GameState.Pause);

        blackBackgroundObject.SetActive(true);
        settingsPopUpObject.SetActive(true);

        blackBackgroundImage.DOFade(0.8f, animationDuration).SetEase(Ease.Linear);
        settingsPopUpObject.transform.DOScale(1.5f, animationDuration).SetEase(Ease.OutBack);
    }

    private void ResumeButtonClicked(){

        blackBackgroundImage.DOFade(0f, animationDuration).SetEase(Ease.Linear);
        settingsPopUpObject.transform.DOScale(0f, animationDuration).SetEase(Ease.InBack).OnComplete(() => {
            blackBackgroundObject.SetActive(false);
            settingsPopUpObject.SetActive(false);
            GameManager.Instance.ChangeGameState(GameState.Resume);
        });

        
    }
}
