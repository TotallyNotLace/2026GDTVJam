using ScriptableObjects;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Model Settings")]
    [SerializeField] private Vector3 rotationAngle;

    [Header("Object References")]
    [SerializeField] private GameObject model;
    [SerializeField] private ProjectileObject stats;

    //hidden stats
    private int piercing;

    private void Start()
    {
        Destroy(this.gameObject, stats.lifeTime);
        piercing = stats.piercing;
    }
    private void Update()
    {
        model.transform.Rotate(rotationAngle * stats.spinSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * stats.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //GetComponent<T>().DoTheDamage(stats.damage);
            HandleEnemyHit();
        }
    }

    private void HandleEnemyHit()
    {
        if(piercing == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        piercing--;
    }
}
