using UnityEditor.ShortcutManagement;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostabel
{
    [SerializeField] private Animator spatulaAnimator;
    [SerializeField] private SpatulaDesignSO spatulaDesignSO;
    [SerializeField] private float jumpForce;
    private bool isActive;
    public void Boost(PlayerControl playerController)
    {
        if (isActive) return;
        PlayBoostAnimation();
        Rigidbody playerrigidbody = playerController.GetPlayerRigidbody();

        playerrigidbody.linearVelocity = new Vector3(playerrigidbody.linearVelocity.x, 0f, playerrigidbody.linearVelocity.z);
        playerrigidbody.AddForce(transform.forward * spatulaDesignSO.ExtraJumpForce, ForceMode.Impulse);
        isActive = true;
        Invoke(nameof(ResetActivition), 0.2f);
    }

    private void PlayBoostAnimation(){
        spatulaAnimator.SetTrigger(Consts.SpatulaBoosterJump.SPATULA_JUMP);
    }

    private void ResetActivition(){
        isActive = false;
    }
}
