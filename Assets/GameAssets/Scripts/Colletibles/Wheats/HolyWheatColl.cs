using UnityEngine;
using UnityEngine.UI;

public class HolyWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private PlayerStateUI playerStateUI;
    private RectTransform playerBoosterTransform;
    private Image playerBoosterImage;
    void Awake()
    {
        playerBoosterTransform = playerStateUI.GetBoosterJumpTransform;
        playerBoosterImage = playerBoosterTransform.GetComponent<Image>();
    }
    public void CollectWheat(){
        playerController.SetJumpForce(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);

        playerStateUI.PlayBoosterUI(playerBoosterTransform, playerBoosterImage, playerStateUI.GetHolyWheatBoosterImage, wheatDesignOS.ActiveSprite, wheatDesignOS.PassiveSprite, wheatDesignOS.ActiveWheatSprite, wheatDesignOS.PassiveWheatSprite, wheatDesignOS.ResetBoostDuration);

        Destroy(gameObject);
    }
}
