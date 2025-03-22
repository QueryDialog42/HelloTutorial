using UnityEngine;

public class HolyWheatColl : MonoBehaviour
{
    [Header("Holy Wheat Settings")]
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private float jumpForceIncrease;
    [SerializeField] private float resetCoolDown;
    public void CollectWheat(){
        playerController.SetJumpForce(jumpForceIncrease, resetCoolDown);
        Destroy(gameObject);
    }
}
