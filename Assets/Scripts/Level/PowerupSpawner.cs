using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerupPrefabs;
    [SerializeField] private SpawnPointManager spawnPointManager;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomPowerup();
        }
    }

    private void SpawnRandomPowerup()
    {
        GameObject prefab = GetRandomPowerup();
        Transform spawnPoint = spawnPointManager.GetRandomSpawnPoint();
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    private GameObject GetRandomPowerup()
    {
        return powerupPrefabs[Random.Range(0, powerupPrefabs.Count)];
    }
}