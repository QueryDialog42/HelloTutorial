using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePopUpScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TimerUI timerUI;

    void OnEnable()
    {
        timerText.text = timerUI.GetFinalTime;
        tryAgainButton.onClick.AddListener(TryAgainButtonClicked);
    }

    private void TryAgainButtonClicked(){
        SceneManager.LoadScene(Consts.GameScene.GAME_SCENE); // to restart game scene
    }
}
