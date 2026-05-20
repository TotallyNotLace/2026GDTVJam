using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyImpact : MonoBehaviour
{
    [SerializeField] private UnityEvent bumpedPlayer;
    [SerializeField] private EnemyObject stats;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Life>().TakeDamage(stats.damage);
        }
    }
}