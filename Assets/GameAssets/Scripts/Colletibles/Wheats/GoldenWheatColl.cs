using UnityEngine.UI;
using UnityEngine;

public class GoldenWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private PlayerStateUI playerStateUI;

    private RectTransform playerBoosterTransform;
    private Image playerBoosterImage;
    void Awake()
    {
        playerBoosterTransform = playerStateUI.GetBoosterSpeedTransform;
        playerBoosterImage = playerBoosterTransform.GetComponent<Image>();
    }
    public void CollectWheat(){
        playerController.SetMovementSpeed(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);

        playerStateUI.PlayBoosterUI(playerBoosterTransform, playerBoosterImage, playerStateUI.GetGoldenWheatBoosterImage, wheatDesignOS.ActiveSprite, wheatDesignOS.PassiveSprite, wheatDesignOS.ActiveWheatSprite, wheatDesignOS.PassiveWheatSprite, wheatDesignOS.ResetBoostDuration);

        Destroy(gameObject);
    }
}
