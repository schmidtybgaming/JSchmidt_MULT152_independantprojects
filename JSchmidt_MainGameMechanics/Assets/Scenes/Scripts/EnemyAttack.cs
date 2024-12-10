using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackInterval = 1.0f;
    public int numberOfAttacks = 5;
    private int hitCount = 0; // Track the number of hits on the enemy
    public int playerHealth = 10; // Player health starts at 10

    void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            for (int i = 0; i < numberOfAttacks; i++)
            {
                Attack();
                yield return new WaitForSeconds(attackInterval);
            }
            // Wait before starting the next series of attacks
            yield return new WaitForSeconds(attackInterval * 2);
        }
    }

    void Attack()
    {
        // Implement attack logic here if needed
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hitCount++; // Increment hit count on the enemy
            Destroy(collision.gameObject); // Optionally, destroy the projectile

            if (hitCount >= 5)
            {
                Destroy(gameObject); // Destroy the enemy object after 5 hits
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth--; // Decrease player health by 1

            if (playerHealth <= 0)
            {
                Debug.Log("Player Died");
                // Implement player death logic here, e.g., reload scene, show game over screen, etc.
            }
        }
    }
}
