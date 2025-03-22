using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private PlayerControl playerController;
    private StateController stateController;
    private PlayerState playerState;

    private void Awake()
    {
        playerController = GetComponent<PlayerControl>();
        stateController = GetComponent<StateController>();
    }

    private void Start()
    {
        playerController.OnPlayerJump += PlayerController_OnPlayerJumped;
    }

    private void Update()
    {
        SetPlayerAnimations();
    }

    private void SetPlayerAnimations(){
        playerState = stateController.GetCurrentState();
        switch(playerState){
            case PlayerState.Idle:
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, false);
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE, false);
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING, false);
                playerController.isSliding = false;
                break;
            case PlayerState.Move:
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, false);
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING, true);
                break;
            case PlayerState.SlideIdle:
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE, false);
                break;
            case PlayerState.Slide:
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE, true);
                break;

        }
    }

    private void PlayerController_OnPlayerJumped(){
        playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING, true);
        Invoke(nameof(ResetJump), playerController.jumpCoolDown);
    }

    private void ResetJump(){
        playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING, false);
    }
}
