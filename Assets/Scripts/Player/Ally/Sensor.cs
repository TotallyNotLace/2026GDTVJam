using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Player.Ally
{

    public class Sensor : MonoBehaviour
    {
        [SerializeField] private List<GameObject> detectedObjects;

        [SerializeField] private string targetTag;

        public UnityEvent<GameObject> detectionTargetEntered;
        public UnityEvent<GameObject> detectionTargetLeft;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                detectedObjects.Add(other.gameObject);
                detectionTargetEntered.Invoke(other.gameObject);
                Debug.Log($"Enemy {other.gameObject.name} detected.");
                other.gameObject.GetComponent<Enemy>().deathEvent += EnemyLeaveLogic;

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (detectedObjects.Contains(other.gameObject))
            {
                other.GetComponent<Enemy>().deathEvent -= EnemyLeaveLogic;
                EnemyLeaveLogic(gameObject);
            }
        }

        private void EnemyLeaveLogic(GameObject other)
        {
            
            detectedObjects.Remove(other.gameObject);
            detectionTargetLeft.Invoke(other.gameObject);
        }
    }

}
