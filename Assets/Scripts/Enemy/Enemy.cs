using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private EnemyPool _pool;

    public Action<GameObject> deathEvent;

    public void Init(EnemyPool pool)
    {
        _pool = pool;
    }

    public void OnEndOfLife()
    {
        _pool.Release(this);
        deathEvent?.Invoke(this.gameObject);
    }
}