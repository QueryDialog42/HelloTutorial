using UnityEngine;
using UnityEngine.UI;

public class DarkWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private PlayerStateUI playerStateUI;
    private RectTransform playerBoosterTransform;
    private Image playerBoosterImage;
    void Awake()
    {
        playerBoosterTransform = playerStateUI.GetBoosterDarkTransform;
        playerBoosterImage = playerBoosterTransform.GetComponent<Image>();
    }
    public void CollectWheat(){
        playerController.SetMovementSpeed(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);

        playerStateUI.PlayBoosterUI(playerBoosterTransform, playerBoosterImage, playerStateUI.GetDarkWheatBoosterImage, wheatDesignOS.ActiveSprite, wheatDesignOS.PassiveSprite, wheatDesignOS.ActiveWheatSprite, wheatDesignOS.PassiveWheatSprite, wheatDesignOS.ResetBoostDuration);

        Destroy(gameObject);
    }
}
