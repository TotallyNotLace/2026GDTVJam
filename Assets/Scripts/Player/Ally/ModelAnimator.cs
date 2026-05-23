using UnityEngine;
using UnityEngine.Events;

namespace Player.Ally
{
    public class ModelAnimator : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent throwComplete;
        [SerializeField] private UnityEvent throwApex;

        [Header("Object References")]
        [SerializeField] private Animator anim;
        [SerializeField] private Transform modelTrans;
        [SerializeField] private Transform handLocation;

        [Header("Settings")]
        [SerializeField] private Vector3 neutralPos;

        private void Update()
        {
            modelTrans.localPosition = neutralPos;
        } 

        public void OnThrowEvent()
        {
            anim.SetTrigger("Throw");
        }

        public void OnThrowApex()
        {
            throwApex.Invoke();
        }

        public void OnThrowComplete()
        {
            throwComplete.Invoke();
        }

        public void OnMovementSpeedChange(float speed)
        {
            anim.SetFloat("Blend", speed);
        }

        public void PickupMode(bool mode)
        {
            anim.SetBool("Pickup", mode);
        }

        public Transform GetHandLocation()
        {
            return handLocation;
        }
    }
}
