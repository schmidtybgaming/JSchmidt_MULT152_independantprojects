using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackPowerup : MonoBehaviour
{
    public GameObject jetpackPrefab; // Prefab for the jetpack
    public Transform[] spawnPoints; // Array of spawn points for jetpacks
    public float powerupDuration = 5f; // Duration of the jetpack power-up

    private GameObject[] activeJetpacks;

    void Start()
    {
        activeJetpacks = new GameObject[spawnPoints.Length];
        SpawnJetpacks();
    }

    void SpawnJetpacks()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            activeJetpacks[i] = Instantiate(jetpackPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateJetpack(other.gameObject);
        }
    }

    void ActivateJetpack(GameObject player)
    {
        for (int i = 0; i < activeJetpacks.Length; i++)
        {
            if (activeJetpacks[i] != null)
            {
                Destroy(activeJetpacks[i]);
                activeJetpacks[i] = Instantiate(jetpackPrefab, player.transform);
                StartCoroutine(JetpackDuration(player, i));
                break;
            }
        }
    }

    System.Collections.IEnumerator JetpackDuration(GameObject player, int index)
    {
        // Enable jetpack functionality here
        player.GetComponent<Rigidbody>().useGravity = false;

        yield return new WaitForSeconds(powerupDuration);

        // Disable jetpack functionality here
        player.GetComponent<Rigidbody>().useGravity = true;
        Destroy(activeJetpacks[index]);
    }
}


