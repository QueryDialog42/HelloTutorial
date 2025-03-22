using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerControl playerController;
    void Awake()
    {
        playerController = GetComponent<PlayerControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IColletible>(out var colletible)){
            colletible.CollectWheat();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostabel>(out var boostabel)){
            boostabel.Boost(playerController);
        }
    }
}
