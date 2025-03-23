using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("References")]
    [SerializeField] private EggCounterUI eggCounterUI;
    [Header("Settings")]
    [SerializeField] private int maxEggCount = 5;

    private int currentEggCount;

    void Awake()
    {
        Instance = this;
    }

    public void OnEggCollected(){
        currentEggCount++;
         eggCounterUI.SetEggCounterText(currentEggCount, maxEggCount);
        if (currentEggCount == maxEggCount){
            eggCounterUI.SetEggCompleted();
        }
    }
}
