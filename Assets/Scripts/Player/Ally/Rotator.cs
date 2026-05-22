using System.Collections.Generic;
using UnityEngine;

namespace Player.Ally
{
    public class Rotator : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float rotationSpeed = 10f;

        [Header("Object References")]
        [SerializeField] private List<GameObject> detectedEnemies;
        [SerializeField] private GameObject model;

        private Vector3 _moveDirection;

        private void Update()
        {
            Rotation();
        }

        public void SetMoveDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }

        private void Rotation()
        {
            Vector3 direction;

            if (detectedEnemies.Count > 0)
                direction = detectedEnemies[0].transform.position - transform.position;
            else
                direction = _moveDirection;

            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                model.transform.rotation = Quaternion.Slerp(
                    model.transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }

        public void NewEnemy(GameObject newEnemy)
        {
            detectedEnemies.Add(newEnemy);
        }

        public void EnemyLeft(GameObject leftEnemy)
        {
            if (!detectedEnemies.Contains(leftEnemy)) return;
            detectedEnemies.Remove(leftEnemy);
        }
    }
}