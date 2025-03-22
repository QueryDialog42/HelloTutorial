using UnityEngine;

public class GoldenWheatColl : MonoBehaviour
{
    [Header("Golden Wheat Settings")]
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private float movementIncrease;
    [SerializeField] private float resetCoolDown;
    public void CollectWheat(){
        playerController.SetMovementSpeed(movementIncrease, resetCoolDown);
        Destroy(gameObject);
    }
}
