using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    
    private void GameOver()
    {
        
        Debug.Log("Game Over!");

        
        Time.timeScale = 0f;

        
    }
}
