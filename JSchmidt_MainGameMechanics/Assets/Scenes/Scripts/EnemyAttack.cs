using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float attackInterval = 1.0f;
    public int numberOfAttacks = 5;

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
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
