using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<GameState> OnGameStateChanged;

    [Header("References")]
    [SerializeField] private EggCounterUI eggCounterUI;
    [SerializeField] private WinLoseUI winLoseUI;
    [Header("Settings")]
    [SerializeField] private int maxEggCount = 5;

    private int currentEggCount;

    private GameState currentGameState;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        ChangeGameState(GameState.Play);
    }

    public void OnEggCollected(){
        currentEggCount++;
        eggCounterUI.SetEggCounterText(currentEggCount, maxEggCount);
        if (currentEggCount == maxEggCount){
            eggCounterUI.SetEggCompleted();
            ChangeGameState(GameState.GameOver);
            winLoseUI.OnGameWin();
        }
    }

    public void ChangeGameState(GameState gamestate){
        OnGameStateChanged?.Invoke(gamestate);
        currentGameState = gamestate;
    }

    public GameState GetCurrentGameState => currentGameState;
}
