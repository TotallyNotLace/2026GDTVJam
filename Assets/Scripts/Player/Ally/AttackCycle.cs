using System.Collections;
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

        [SerializeField] private Transform model;

        [SerializeField] private ModelAnimator modelAnimator;

        [SerializeField] private ProjectilePool projectilePool;
        private bool throwComplete = false;
        private Coroutine _attackCoroutine;

        private void Start()
        {
            isAttacking = false;
        }

        public void StartAttack()
        {
            if (isAttacking) return;

            _attackCoroutine = StartCoroutine(AttackPeriod());
        }

        public void StopAttack()
        {
            isAttacking = false;
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
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
            isAttacking = true;
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