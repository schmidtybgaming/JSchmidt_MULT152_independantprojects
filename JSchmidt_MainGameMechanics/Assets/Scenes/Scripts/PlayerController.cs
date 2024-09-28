using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isJetpackEnabled = false;

    public void EnableJetpack(bool enable)
    {
        isJetpackEnabled = enable;
        // Add your jetpack logic here, e.g., enabling flight mode, changing player speed, etc.
    }

    void Update()
    {
        if (isJetpackEnabled)
        {
            // Handle jetpack movement here
        }
    }
}

