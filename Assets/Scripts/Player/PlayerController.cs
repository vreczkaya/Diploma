using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private CapsuleCollider model;

    [Header("Movement")]
    [SerializeField, Range(1f, 15f)]
    private float moveSpeed;

    [SerializeField, Range(1f, 15f)]
    private float groundDrag;

    [SerializeField, Range(1f, 15f)]
    private float jumpForce;
    [SerializeField, Range(0f, 15f)]
    private float jumpCooldown;
    [SerializeField, Range(1f, 15f)]
    private float airMultiplier;

    private bool isReadyToJump;


    [Header("Ground Check")]
    
    [SerializeField, Range(1f, 15f)]
    private float playerHeight;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;

    [SerializeField]
    private Transform orientation;

    private Vector3 moveDirection;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        model = GetComponentInChildren<CapsuleCollider>();

        rigidBody.freezeRotation = true;

        isReadyToJump = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        ControlSpeed();

        rigidBody.drag = isGrounded ? groundDrag : 0;
    }

    public void Jump()
    {
        if (isReadyToJump && isGrounded)
        {
            isReadyToJump = false;

            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

            rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    public void RotateModel(Vector3 end, float time)
    {
        model.transform.forward = Vector3.Slerp(model.transform.forward, end, time);
    }

    public void Move(float verticalInput, float horizontalInput)
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rigidBody.AddForce(CalculateForce(), ForceMode.Force);
    }

    private Vector3 CalculateForce()
    {
        return isGrounded ? moveDirection.normalized * moveSpeed * 10f : moveDirection.normalized * moveSpeed * 10f * airMultiplier;
    }

    private void ControlSpeed()
    {
        Vector3 flatVelocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rigidBody.velocity = new Vector3(limitedVelocity.x, rigidBody.velocity.y, limitedVelocity.z);
        }
    }

    
    private void ResetJump()
    {
        isReadyToJump = true;
    }
}