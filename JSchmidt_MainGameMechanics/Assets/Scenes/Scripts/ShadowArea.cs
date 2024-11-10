using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArea : MonoBehaviour
{
    public bool flashlightOn = true; // Initial state of the flashlight

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Toggle flashlight with the 'F' key
        if (Input.GetKeyDown(KeyCode.O))
        {
            flashlightOn = !flashlightOn;
            Debug.Log("Flashlight toggled: " + (flashlightOn ? "On" : "Off"));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!flashlightOn)
            {
                Player.isHidden = true;
                Debug.Log("PlayerHidden");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.isHidden = false;
        }
    }
}
