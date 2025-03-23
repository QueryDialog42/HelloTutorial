using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform timerRotatableTransform;
    [SerializeField] private TMP_Text timertext;
    [Header("Timer Settings")]
    [SerializeField] private float timeDuration;
    [SerializeField] private Ease rotationEase;

    private float elapsedTime;

    void Start()
    {
        PlayRotationAnimation();
        StartTimer();
    }
    private void PlayRotationAnimation(){
        timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), timeDuration, RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart).SetEase(rotationEase); // -1 = infinity
    }

    private void StartTimer(){
        elapsedTime = 0f;
        InvokeRepeating(nameof(UpdateTimeUI), 0f, 1f); // every 1 second
    }

    private void UpdateTimeUI(){
        elapsedTime++;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
