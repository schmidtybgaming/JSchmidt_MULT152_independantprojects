using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordActivator : MonoBehaviour
{
    public GameObject boxPink;
    public GameObject boxLime;
    public GameObject boxClay;
    public GameObject boxSea;

    private bool hasPasswordPink = false;
    private bool hasPasswordLime = false;
    private bool hasPasswordClay = false;
    private bool hasPasswordSea = false;

    public HUDController hudController; // Reference to the HUDController
    public UIManager uiManager;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Password Pink"))
        {
            hasPasswordPink = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Pink!");
            hudController.IncrementCodes(); // Update the codes HUD
        }
        else if (other.gameObject.CompareTag("Password Lime"))
        {
            hasPasswordLime = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Lime!");
            hudController.IncrementCodes(); // Update the codes HUD
        }
        else if (other.gameObject.CompareTag("Password Clay"))
        {
            hasPasswordClay = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Clay!");
            hudController.IncrementCodes(); // Update the codes HUD
        }
        else if (other.gameObject.CompareTag("Password Sea"))
        {
            hasPasswordSea = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Sea!");
            hudController.IncrementCodes(); // Update the codes HUD
        }

        ActivateBoxes();
    }

    void ActivateBoxes()
    {
        if (hasPasswordPink)
        {
            boxPink.SetActive(true);
            Debug.Log("Box Pink activated!");
            hudController.IncrementHackedBoxes(); // Update the hacked boxes HUD
        }
        if (hasPasswordLime)
        {
            boxLime.SetActive(true);
            Debug.Log("Box Lime activated!");
            hudController.IncrementHackedBoxes(); // Update the hacked boxes HUD
        }
        if (hasPasswordClay)
        {
            boxClay.SetActive(true);
            Debug.Log("Box Clay activated!");
            hudController.IncrementHackedBoxes(); // Update the hacked boxes HUD
        }
        if (hasPasswordSea)
        {
            boxSea.SetActive(true);
            Debug.Log("Box Sea activated!");
            hudController.IncrementHackedBoxes();
            uiManager.ShowWinMenu();
        }
    }
}