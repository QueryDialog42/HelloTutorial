using System;
using DG.Tweening;
using JetBrains.Annotations;
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

    private bool isTimerRunning;
    private Tween rotationTween; // for Pause() and Play() animations
    private string finalTime;

    void Start()
    {
        PlayRotationAnimation();
        StartTimer();

        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState gamestate)
    {
        switch(gamestate){
            case GameState.Pause:
                StopTimer();
                break;
            case GameState.Resume:
                ResumeTimer();
                break;
            case GameState.GameOver:
                FinishTimer();
                break;
        }
    }

    private void PlayRotationAnimation(){
        rotationTween = timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), timeDuration, RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart).SetEase(rotationEase); // -1 = infinity
    }

    private void StartTimer(){
        isTimerRunning = true;
        elapsedTime = 0f;
        InvokeRepeating(nameof(UpdateTimeUI), 0f, 1f); // every 1 second
    }

    private void UpdateTimeUI(){
        if (isTimerRunning == false) {return;}
        elapsedTime++;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void StopTimer(){
        isTimerRunning = false;
        CancelInvoke(nameof(UpdateTimeUI));
        rotationTween.Pause();
    }

    private void ResumeTimer(){
        if (isTimerRunning == false){
            isTimerRunning = true;
            InvokeRepeating(nameof(UpdateTimeUI), 0f, 1f);
            rotationTween.Play();
        }
    }

    private void FinishTimer(){
        StopTimer();
        finalTime = GetFormattedElapsedTime();
    }

    private string GetFormattedElapsedTime(){
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetFinalTime => finalTime;
}
