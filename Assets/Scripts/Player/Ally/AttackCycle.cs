using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

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

        [SerializeField] private Transform model;

        //[SerializeField] private Projectile projectilePrefab;

        [SerializeField] private ModelAnimator modelAnimator;

        [SerializeField] private ProjectilePool projectilePool;
        private bool throwComplete = false;


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

        public void OnThrowComplete()
        {
            throwComplete = true;
        }

        public void OnThrowApex()
        {
            Projectile projectile = projectilePool.Get();
            projectile.Init(projectilePool);
            projectile.transform.SetPositionAndRotation(transform.position, model.rotation);

        }

        private IEnumerator AttackPeriod()
        {

            while (isAttacking)
            {
                //start attack animation
                throwComplete = false;
                modelAnimator.OnThrowEvent();
                //wait for throw complete.
                yield return new WaitUntil(() => throwComplete);
                //wait for delay.
                yield return new WaitForSeconds(attackDelay);
                //return to the start of the coroutine
            }
        }
    }
}