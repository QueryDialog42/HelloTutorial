using UnityEngine;

public class HolyWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    public void CollectWheat(){
        playerController.SetJumpForce(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);
        Destroy(gameObject);
    }
}
