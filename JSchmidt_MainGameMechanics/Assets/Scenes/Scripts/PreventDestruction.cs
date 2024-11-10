using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDestruction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Prevent destruction by doing nothing
            // Optionally, you can add other logic here
            Debug.Log("Collision with projectile detected, but prefab is not destroyed.");
        }
    }
}
