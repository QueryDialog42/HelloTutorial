using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopUpScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button oneMoreButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TimerUI timerUI;

    void OnEnable()
    {
        timerText.text = timerUI.GetFinalTime;
        oneMoreButton.onClick.AddListener(OnOneMoreButtonClicked);
    }

    private void OnOneMoreButtonClicked(){
        SceneManager.LoadScene(Consts.GameScene.GAME_SCENE);
    }
}
