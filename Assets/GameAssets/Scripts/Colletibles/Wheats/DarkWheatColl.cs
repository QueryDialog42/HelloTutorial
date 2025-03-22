using UnityEngine;

public class DarkWheatColl : MonoBehaviour, IColletible
{
    [SerializeField] private WheatDesignOS wheatDesignOS;
    [SerializeField] private PlayerControl playerController;
    public void CollectWheat(){
        playerController.SetMovementSpeed(wheatDesignOS.IncreaseDecreaseMultiplier, wheatDesignOS.ResetBoostDuration);
        Destroy(gameObject);
    }
}
