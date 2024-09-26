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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.gameObject.CompareTag("PasswordPink"))
        {
            hasPasswordPink = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Pink!");
        }
        else if (other.gameObject.CompareTag("PasswordLime"))
        {
            hasPasswordLime = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Lime!");
        }
        else if (other.gameObject.CompareTag("PasswordClay"))
        {
            hasPasswordClay = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Clay!");
        }
        else if (other.gameObject.CompareTag("PasswordSea"))
        {
            hasPasswordSea = true;
            Destroy(other.gameObject);
            Debug.Log("Picked up Password Sea!");
        }

        ActivateBoxes();
    }

    void ActivateBoxes()
    {
        if (hasPasswordPink)
        {
            boxPink.SetActive(true);
            Debug.Log("Box Pink activated!");
        }
        if (hasPasswordLime)
        {
            boxLime.SetActive(true);
            Debug.Log("Box Lime activated!");
        }
        if (hasPasswordClay)
        {
            boxClay.SetActive(true);
            Debug.Log("Box Clay activated!");
        }
        if (hasPasswordSea)
        {
            boxSea.SetActive(true);
            Debug.Log("Box Sea activated!");
        }
    }
}
