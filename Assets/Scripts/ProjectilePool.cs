using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    private IObjectPool<Projectile> _pool;

    void Awake()
    {
        _pool = new ObjectPool<Projectile>(
            createFunc: CreateProjectile,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyProjectile,
            collectionCheck: true,
            defaultCapacity: 5,
            maxSize: 10
        );
    }

    private Projectile CreateProjectile()
    {
        Projectile p = Instantiate(projectilePrefab);
        p.gameObject.SetActive(false);
        return p;
    }

    private void OnGet(Projectile p)
    {
        p.gameObject.SetActive(true);
    }

    private void OnRelease(Projectile p)
    {
        p.gameObject.SetActive(false);
    }

    private void OnDestroyProjectile(Projectile p)
    {
        Destroy(p.gameObject);
    }

    public Projectile Get()
    {
        return _pool.Get();
    }

    public void Release(Projectile p)
    {
        _pool.Release(p);
    }
}