using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SubTriggerManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> triggerEvent;
    [SerializeField] private UnityEvent<GameObject> collisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionEvent.Invoke(collision.gameObject);
    }
}
