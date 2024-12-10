using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight; // Assign your flashlight (Spotlight) in the Inspector
    private bool isOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}

