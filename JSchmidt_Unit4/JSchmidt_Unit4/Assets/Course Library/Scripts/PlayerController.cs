using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float speed = 5.0f;
    GameObject focalPoint;
    Renderer rendererPlayer;
    bool hasPowerUp = false;
    public float powerUpSpeed = 10.0f;
    public GameObject powerUpInd;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        rendererPlayer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * forwardInput * magnitude, ForceMode.Impulse);

        if (forwardInput > 0)
        {
            rendererPlayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            rendererPlayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }

        powerUpInd.transform.position = transform.position;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            powerUpInd.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collid with" + collision.gameObject + "with powerup set to: " + hasPowerUp);
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDir = collision.gameObject.transform.position = transform.position;
            rbEnemy.AddForce(awayDir * powerUpSpeed, ForceMode.Impulse);
        }

    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpInd.SetActive(false);
    }
}