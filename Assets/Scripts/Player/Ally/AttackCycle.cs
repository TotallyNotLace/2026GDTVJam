using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Ally
{
    public class AttackCycle : MonoBehaviour
    {
        [Header("Settings")]
        private bool isAttacking;
        [SerializeField] private float attackDelay;
        [SerializeField] private float animationLength;

        [Header("Object References")]
        [SerializeField] private Material atkMaterial;
        [SerializeField] private Material nmlMaterial;

        [SerializeField] private MeshRenderer model;

        [SerializeField] private GameObject projectilePrefab;

        private void Start()
        {
            isAttacking = false;
        }

        public void StartAttack()
        {
            if (isAttacking) return;
            isAttacking = true;
            StartCoroutine(AttackPeriod());
        }

        public void StopAttack()
        {
            isAttacking = false;
        }

        private IEnumerator AttackPeriod()
        {
            yield return new WaitForSeconds(attackDelay);
            
            while (isAttacking)
            {

                model.material = atkMaterial;
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(animationLength);
                model.material = nmlMaterial;

                yield return new WaitForSeconds(attackDelay);
            }
        }


    }
}