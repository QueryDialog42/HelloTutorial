using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private KeyCode movementKey;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCoolDown;

    [Header("Ground Check Settings")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groudDrag;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode slideKey;
    [SerializeField] private float slideMultiplier;
    [SerializeField] private float slideDrag;

    private Vector3 movementDirection;
    private Rigidbody playerrigidbody;
    private float horizontalInput, verticalInput;
    private bool canJump = true;
    private bool isSliding = false;

    private void Awake()
    {
        playerrigidbody = GetComponent<Rigidbody>();   
        playerrigidbody.freezeRotation = true;
    }

    private void Update()
    {
        SetInput();
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
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(isSliding)
        {
            playerrigidbody.AddForce(movementDirection.normalized * movementSpeed * slideMultiplier, ForceMode.Force);
        }
        else{
             playerrigidbody.AddForce(movementDirection.normalized * movementSpeed, ForceMode.Force);
        }
    }

    private void SetPlayerJump()
    {
        canJump = false;
        playerrigidbody.linearVelocity = new Vector3(playerrigidbody.linearVelocity.x, 0f, playerrigidbody.linearVelocity.z);
        playerrigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        Invoke(nameof(ResetJump), jumpCoolDown);
    }

    private void SetPlayerDrag()
    {
        if(isSliding){
            playerrigidbody.linearDamping = slideDrag;
        }
        else{
            playerrigidbody.linearDamping = groudDrag; //linearDamping = Drag
        }
        
    }

    private void LimitPlayerSpeed(){
        Vector3 flatVelocity = new Vector3(playerrigidbody.linearVelocity.x, 0f, playerrigidbody.linearVelocity.z);
        if(flatVelocity.magnitude > movementSpeed){
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            playerrigidbody.linearVelocity = new Vector3(limitedVelocity.x, playerrigidbody.linearVelocity.y, limitedVelocity.z);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
    }

    private void ResetJump()
    {
        canJump = true;
    }
}
