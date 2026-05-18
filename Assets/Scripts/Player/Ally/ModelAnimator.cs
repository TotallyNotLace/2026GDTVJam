using System.Collections;
using UnityEditor.Animations;
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
    }
}
