using System.Collections;
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

    private bool isAlive = false;

    private Coroutine movement;

    private void Start()
    {
        //Destroy(this.gameObject, stats.lifeTime);
        piercing = stats.piercing;
        movement = StartCoroutine(MoveCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.gameObject.name} hit object: {other.gameObject.name}");
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Life>().TakeDamage(stats.damage);
            HandleEnemyHit();
        }
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
            isAlive = false;
            //StopCoroutine(movement);
            this.gameObject.SetActive(false);
            return;
        }
        piercing--;
    }
}
