using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private UnityEvent<Enemy> enemyDefeated;

    private IObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc:      CreateEnemy,
            actionOnGet:     OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyEnemy,
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 50
        );
    }

    private Enemy CreateEnemy()
    {
        Enemy e = Instantiate(enemyPrefab);
        e.gameObject.SetActive(false);
        return e;
    }

    private void OnGet(Enemy e)
    {
        e.gameObject.SetActive(true);
    }

    private void OnRelease(Enemy e)
    {
        e.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy e)
    {
        Destroy(e.gameObject);
    }

    public Enemy Get()
    {
        return _pool.Get();
    }

    public void Release(Enemy e)
    {
        enemyDefeated?.Invoke(e);
        _pool.Release(e);
    }
}