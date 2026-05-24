using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    private void OnValidate()
    {
        spawnPoints.Clear();
        foreach (Transform group in transform)
        {
            foreach (Transform spawnPoint in group)
            {
                spawnPoints.Add(spawnPoint);
            }
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    public Transform GetSpawnPoint(int index)
    {
        return spawnPoints[index];
    }
}
