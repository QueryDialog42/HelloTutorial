using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState currentPlayerState;

    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }

    public void ChangeState(PlayerState newPlayerState){
        if (currentPlayerState == newPlayerState){return;}
        currentPlayerState = newPlayerState;
    }

    public PlayerState GetCurrentState(){
        return currentPlayerState;
    }
}
