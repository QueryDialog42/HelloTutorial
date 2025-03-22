using UnityEngine;

public class GoldenWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    public void CollectWheat(){
        playerController.SetMovementSpeed(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);
        Destroy(gameObject);
    }
}
