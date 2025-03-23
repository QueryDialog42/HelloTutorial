using System.ComponentModel.Design;
using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO")]

public class WheatDesignOS : ScriptableObject
{
    [SerializeField] private float increaseDecreaseMultiplier;
    [SerializeField] private float resetBoostDuration;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite passiveSprite;
    [SerializeField] private Sprite activeWheatSprite;
    [SerializeField] private Sprite passiveWheatSprite;

    public float IncreaseDecreaseMultiplier => increaseDecreaseMultiplier;
    public float ResetBoostDuration => resetBoostDuration;
    public Sprite ActiveSprite => activeSprite;
    public Sprite PassiveSprite => passiveSprite;
    public Sprite ActiveWheatSprite => activeWheatSprite;
    public Sprite PassiveWheatSprite => passiveWheatSprite;
}
