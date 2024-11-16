using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArea : MonoBehaviour
{
    public bool flashlightOn = true; // Initial state of the flashlight
    public bool isInShadow = false;
    public Light flashlight;

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
            flashlight.enabled = flashlightOn;
            Debug.Log("Flashlight toggled: " + (flashlightOn ? "On" : "Off"));
        }

        SetIsHidden();
    }

    void SetIsHidden()
    {
        if (isInShadow && !flashlightOn)
        {
            Player.isHidden = true;
        }

        else
        {
            Player.isHidden = false;
        }

        Debug.Log(Player.isHidden);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))


        {
            isInShadow = true;
            Debug.Log("setting is in shadow to true");
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            isInShadow = false;
            Debug.Log("setting is in shadow to false");
        }
    }
}
