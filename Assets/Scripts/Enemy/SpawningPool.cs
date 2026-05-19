using System.Collections;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval;

    private bool isSpawning = false;

    private void Start()
    {
        StartSpawning();
    }
    
    public void StartSpawning()
    {
        if (isSpawning) return;
        isSpawning = true;
        StartCoroutine(SpawnCycle());
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private IEnumerator SpawnCycle()
    {
        while (isSpawning)
        {
            SpawnEnemy(GetSpawnPoint());
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy(Vector3 position)
    {
        Enemy enemy = enemyPool.Get();
        enemy.Init(enemyPool);
        enemy.transform.SetPositionAndRotation(position, Quaternion.identity);
    }

    private Vector3 GetSpawnPoint()
    {
        return spawnPoint.position;
    }
}