using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public event Action OnPlayerJump;
    public event Action<PlayerState> OnPlayerStateChanged;

    [Header("References")]
    [SerializeField] private Transform orientation;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private KeyCode movementKey;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpForce;
    [SerializeField] private float airMultiplier;
    [SerializeField] private float airDrag;
    [SerializeField] public float jumpCoolDown;

    [Header("Ground Check Settings")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groudDrag;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode slideKey;
    [SerializeField] private float slideMultiplier;
    [SerializeField] private float slideDrag;

    private float startMovementSpeed;
    private float startJumpForce;
    private StateController stateController;
    private Vector3 movementDirection;
    private Rigidbody playerrigidbody;
    private float horizontalInput, verticalInput;
    private bool canJump = true;
    public bool isSliding = false;

    private void Awake()
    {
        stateController = GetComponent<StateController>();
        playerrigidbody = GetComponent<Rigidbody>();   
        playerrigidbody.freezeRotation = true;

        startMovementSpeed = movementSpeed;
        startJumpForce = jumpForce;
    }

    private void Update()
    {
        SetInput();
        SetStates();
        SetPlayerDrag();
        LimitPlayerSpeed();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();   
    }

    private void SetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(slideKey))
        {
            isSliding = true;
        }
        else if (Input.GetKeyDown(movementKey))
        {
            isSliding = false;
        }
        else if(Input.GetKey(jumpKey) && canJump && IsGrounded()){
            SetPlayerJump();
        }
    }

    private void SetPlayerMovement()
    {
        float forceMultiplier = stateController.GetCurrentState() switch{
            PlayerState.Move => 1f,
            PlayerState.Slide => slideMultiplier,
            PlayerState.Jump => airMultiplier,
            _ => 1f
        };
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        playerrigidbody.AddForce(movementDirection.normalized * movementSpeed * forceMultiplier, ForceMode.Force);
    }

    private void SetStates(){
        Vector3 currentMovementDirection = GetMovementDirection();
        bool isgrounded = IsGrounded();
        var currentState = stateController.GetCurrentState();
        bool isSlidingg = IsSliding();
        var newState = currentState switch{
            _ when currentMovementDirection == Vector3.zero && isgrounded => PlayerState.Idle,
            _ when currentMovementDirection != Vector3.zero && isgrounded && !isSlidingg => PlayerState.Move,
            _ when currentMovementDirection != Vector3.zero && isgrounded && isSlidingg => PlayerState.Slide,
            _ when currentMovementDirection == Vector3.zero && isgrounded && isSlidingg => PlayerState.SlideIdle,
            _ when !canJump && !isgrounded => PlayerState.Jump,
            _ => currentState
        };
        if(currentState != newState){
            stateController.ChangeState(newState);
            OnPlayerStateChanged?.Invoke(newState);
        }
    }

    private void SetPlayerJump()
    {
        OnPlayerJump?.Invoke(); // if OnPlayerJump != null
        canJump = false;
        playerrigidbody.linearVelocity = new Vector3(playerrigidbody.linearVelocity.x, 0f, playerrigidbody.linearVelocity.z);
        playerrigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        Invoke(nameof(ResetJump), jumpCoolDown);
    }

    private void SetPlayerDrag()
    {
        playerrigidbody.linearDamping = stateController.GetCurrentState() switch{
            PlayerState.Move => groudDrag,
            PlayerState.Slide => slideDrag,
            PlayerState.Jump => airDrag,
            _ => playerrigidbody.linearDamping
        };
    }

    private void LimitPlayerSpeed(){
        Vector3 flatVelocity = new Vector3(playerrigidbody.linearVelocity.x, 0f, playerrigidbody.linearVelocity.z);
        if(flatVelocity.magnitude > movementSpeed){
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            playerrigidbody.linearVelocity = new Vector3(limitedVelocity.x, playerrigidbody.linearVelocity.y, limitedVelocity.z);
        }
    }

    #region Helper Functions

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
    }

    private void ResetJump()
    {
        canJump = true;
    }

    private Vector3 GetMovementDirection(){
        return movementDirection.normalized;
    }

    private bool IsSliding(){
        return isSliding;
    }

    public void SetMovementSpeed(float speed, float duration){
        movementSpeed += speed;
        Invoke(nameof(ResetMovementSpeed), duration);
    }

    private void ResetMovementSpeed()
    {
        movementSpeed = startMovementSpeed;
    }

    public void SetJumpForce(float force, float duration){
        jumpForce += force;
        Invoke(nameof(ResetJumpForce), duration);
    }

    private void ResetJumpForce()
    {
        jumpForce = startJumpForce;
    }

    public Rigidbody GetPlayerRigidbody(){
        return playerrigidbody;
    }

    #endregion
}
