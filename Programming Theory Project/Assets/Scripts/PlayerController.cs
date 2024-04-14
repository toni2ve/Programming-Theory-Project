using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _minCameraView = -70.0f;
    [SerializeField] private float _maxCameraView = 80.0f;
    [SerializeField] private float mouseSensitivity = 250.0f;

    private Camera _camera;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float walkSpeed = 6.0f;
    private float runSpeed = 12.0f;
    private float playerSpeed;
    private float xRotation = 0.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = walkSpeed;
        playerController = GetComponent<CharacterController>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = playerController.isGrounded;

        MovePlayer();
        JumpPlayer();
        PlayerRotation();

    }

    private void MovePlayer()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift)) // make player run
        {
            playerSpeed = runSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }
        playerController.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }
    }
    private void JumpPlayer()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);
    }
    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;

        // xVelocity = Mathf.Lerp(xVelocity, rotX, mouseSensitivity * Time.deltaTime);
        // yVelocity = Mathf.Lerp(yVelocity, rotY, mouseSensitivity * Time.deltaTime);

        // if (!lockMouseMovement)
        // {
        //RotY
        xRotation = Mathf.Clamp(xRotation, _minCameraView, _maxCameraView);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //RotX
        transform.Rotate(Vector3.up * mouseX);
        // }
    }
}
