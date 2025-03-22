using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO")]

public class WheatDesignOS : ScriptableObject
{
    [SerializeField] private float increaseDecreaseMultiplier;
    [SerializeField] private float resetBoostDuration;

    public float IncreaseDecreaseMultiplier => increaseDecreaseMultiplier;
    public float ResetBoostDuration => resetBoostDuration;
}
