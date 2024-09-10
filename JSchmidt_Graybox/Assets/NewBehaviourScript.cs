using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 40.0f;
    public float jumpForce = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody player;
    public bool isOnGround = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.back * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }
}
