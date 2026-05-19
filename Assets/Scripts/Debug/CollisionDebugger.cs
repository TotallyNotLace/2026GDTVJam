using UnityEngine;

public class CollisionDebugger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"I triggered {other.gameObject.name}.");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"I collided with {collision.gameObject.name}.");
    }
}
