using UnityEngine;

public class DarkWheatColl : MonoBehaviour
{
    [Header("Dark Wheat Settings")]
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private float movementDecrease;
    [SerializeField] private float resetCoolDown;
    public void CollectWheat(){
        playerController.SetMovementSpeed(movementDecrease, resetCoolDown);
        Destroy(gameObject);
    }
}
