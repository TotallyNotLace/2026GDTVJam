using System;
using UnityEngine;
using UnityEngine.Events;


public class Enemy : MonoBehaviour
{

    [SerializeField] private UnityEvent enemyStarted;
    private EnemyPool _pool;

    [SerializeField] private EnemyAnimator initializeAnim;

    [SerializeField] private Collider col;
    public Action<GameObject> deathEvent;
    [SerializeField] private BasicNavAgent agent;

    [SerializeField] private UnityEvent startDeathAnimation;

    public float scoreValue;

    private void Awake()
    {
        initializeAnim.InitAnim();
    }
    public void Init(EnemyPool pool, MainAllyController player)
    {
        agent.SetTarget(player.gameObject.transform);
        col.enabled = true;
        _pool = pool;
        enemyStarted?.Invoke();
    }

    public void OnEndOfLife()
    {
        col.enabled = false;
        deathEvent?.Invoke(this.gameObject);
        startDeathAnimation?.Invoke();
    }

    public void CompleteDeathCycle()
    {
        _pool.Release(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathFloor"))
        {
            OnEndOfLife();
        }
        if (other.CompareTag("Player"))
        {
            OnEndOfLife();
        }
    }
}