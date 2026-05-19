using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [Header("Model Settings")]
    [SerializeField] private Vector3 rotationAngle;

    [SerializeField] private bool isPoolNull;

    [Header("Object References")]
    [SerializeField] private GameObject model;
    [SerializeField] private ProjectileObject stats;

    //hidden stats
    private int piercing;

    private bool isAlive = false;

    private ProjectilePool _pool;

    public void Init(ProjectilePool pool)
    {
        _pool = pool;
        piercing = stats.piercing;
        StopAllCoroutines();
        StartCoroutine(MoveCycle());
        StartCoroutine(LifeCycle());
        Debug.Log($"I recieved this pool though {pool}");
        Debug.Log($"the pool is {_pool}");
        //Debug.Log($"Init on instance ID: {gameObject.GetInstanceID()}");
    }

    public void OnSubTrigger(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Life>().TakeDamage(stats.damage);
            HandleEnemyHit();
        }
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(stats.lifeTime);
        EndOfLife();
    }
    private IEnumerator MoveCycle()
    {
        isAlive = true;
        while (isAlive)
        {
            model.transform.Rotate(rotationAngle * stats.spinSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * stats.moveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void HandleEnemyHit()
    {
        if (piercing == 0)
        {
            EndOfLife();
        }
        piercing--;
    }

    private void EndOfLife()
    {
        Debug.Log($"End Called ");
        isAlive = false;
        StopAllCoroutines();
        _pool.Release(this);
    }

    void Update()
    {
        isPoolNull = _pool == null;
    }
}
