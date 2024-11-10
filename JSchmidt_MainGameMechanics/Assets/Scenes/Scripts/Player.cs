using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cameraRotater;
    private Vector3 cameraRotateX;
    public static bool isHidden;
    public float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    public GameObject projectile;
    public float jumpForce = 20.0f;
    private Rigidbody playerRB;
    public bool isOnGround = true;
    private float x;
    private float y;
    public float sensitivity = -1.0f;
    private Vector3 rotate;

    private Animator animator;
    public AudioClip laserSound;
    private AudioSource audioSource;

    public int playerHealth = 10; // Player health starts at 10

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Movement
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Animation states
        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("isWalking", true);
            Debug.Log("Walking");
        }
        else
        {
            animator.SetBool("isWalking", false);
            Debug.Log("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, transform.rotation);
            animator.SetTrigger("attack");
            audioSource.PlayOneShot(laserSound);
            Debug.Log("Attack");
        }

        if (Input.GetKeyDown(KeyCode.J) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("jump");
            Debug.Log("Jump");
        }

        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(0, y * sensitivity, 0);
        cameraRotateX = new Vector3(x, 0, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
        cameraRotater.transform.eulerAngles -= cameraRotateX;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth--; // Decrease player health by 1

            if (playerHealth <= 0)
            {
                Debug.Log("Player Died");
                Time.timeScale = 0; // Pause the game
                // Implement additional player death logic here, e.g., show game over screen
            }
        }
    }
}