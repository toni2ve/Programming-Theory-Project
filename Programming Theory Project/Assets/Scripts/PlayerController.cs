using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private float walkSpeed = 6.0f;
    [SerializeField]
    private float runSpeed = 12.0f;
    private float playerSpeed;
    private float xRotation = 0.0f;
    private readonly float jumpHeight = 1.0f;
    private readonly float gravityValue = -9.81f;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private float currentPlayerHealth;
    [SerializeField]
    private float maxPlayerHealth;
    [SerializeField]
    private TMP_Text playerName;
    public Weapon weapon;
    public TMP_Text clipAmmo;
    public TMP_Text extraAmmo;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            if (playerName != null)
            {
                playerName.text = GameManager.Instance.currentPlayerData.PlayerName;
            }

            if (clipAmmo != null)
                GameManager.Instance.ClipAmmo = clipAmmo;

            if (extraAmmo != null)
                GameManager.Instance.ExtraAmmo = extraAmmo;
        }
        currentPlayerHealth = maxPlayerHealth = 1000;
        playerSpeed = walkSpeed;
        playerController = GetComponent<CharacterController>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateClipAmmo(weapon.ClipAmmo);
        UpdateExtraAmmo(weapon.ExtraAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGamePaused)
        {
            groundedPlayer = playerController.isGrounded;

            MovePlayer();
            JumpPlayer();
            PlayerRotation();

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R key pressed");
                ReloadWeapon(weapon);
            }
        }
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

        //RotY
        xRotation = Mathf.Clamp(xRotation, _minCameraView, _maxCameraView);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //RotX
        transform.Rotate(Vector3.up * mouseX);
    }

    public void TakeDamage(float damage)
    {
        currentPlayerHealth -= damage;
        healthBar.UpdateHealth(currentPlayerHealth / maxPlayerHealth);
        if (currentPlayerHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver = true;

            GameManager.Instance.SaveHighscore();
        }
        SceneManager.LoadScene(4);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyPart"))
        {
            // Polymorphism --- the damage value will be retrieve based on the enemy type returned.
            // it can be WeakEnemy, NormalEnemy or StrongEnmy, thus method Damage of that 
            // specific enemy type class will be called.
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            TakeDamage(enemy.Damage);
        }
    }

    private void UpdateClipAmmo(int value)
    {
        GameManager.Instance.UpdateClipAmmoDisplay(value);

    }

    private void UpdateExtraAmmo(int value)
    {
        GameManager.Instance.UpdateExtraAmmoDisplay(value);
    }
    private void ReloadWeapon(Weapon weapon)
    {
        weapon.ReloadWeapon();
    }
}
