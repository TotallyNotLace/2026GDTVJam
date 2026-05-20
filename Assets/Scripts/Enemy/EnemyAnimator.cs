using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEvent deathAnimComplete;

    public void InitAnim()
    {
        anim.SetTrigger("init");
    }

    public void OnEnemyDeath()
    {
        anim.SetTrigger("death");
    }

    public void OnDeathAnimationComplete()
    {
        deathAnimComplete?.Invoke();
    }
}
