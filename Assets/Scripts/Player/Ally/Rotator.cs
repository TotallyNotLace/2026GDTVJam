using System.Collections.Generic;
using UnityEngine;

namespace Player.Ally
{
    public class Rotator : MonoBehaviour
    {
        [Header("Object References")]
        [SerializeField] private List<GameObject> detectedEnemies;
        [SerializeField] private GameObject model;

        private void Update()
        {
            Rotation();
        }

        private void Rotation()
        {
            if (detectedEnemies.Count == 0) return;
            
            Vector3 direction = detectedEnemies[0].transform.position - transform.position;
            direction.y = 0f; // Flatten to horizontal plane only

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                model.transform.rotation = targetRotation;
            }
        }

        public void NewEnemy(GameObject newEnemy)
        {
            detectedEnemies.Add(newEnemy);
        }

        public void EnemyLeft(GameObject leftEnemy)
        {
            if(!detectedEnemies.Contains(leftEnemy)) return;

            detectedEnemies.Remove(leftEnemy);
        }

    }

}
