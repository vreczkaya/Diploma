using UnityEngine;


public class KeyboardInput : MonoBehaviour
{
    private KeyCode jumpKey = KeyCode.Space;

    private float horizontalInput, verticalInput;

    [SerializeField]
    private PlayerController playerController;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        playerController.Move(verticalInput, horizontalInput);

        if (Input.GetKey(jumpKey))
        {
            playerController.Jump();
        }
    }
}
