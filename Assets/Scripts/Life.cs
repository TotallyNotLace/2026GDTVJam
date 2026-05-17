using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;


public class Life : MonoBehaviour
{
    [Header("Life Events")]
    [SerializeField] private UnityEvent<float> LifeChanged;
    [SerializeField] private UnityEvent LifeEnded;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [Header("Object References")]
    [SerializeField] private Entity entity;


    void Start()
    {
        currentHealth = entity.maxLife;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - (damage - (damage * entity.defense / 100));

        if (currentHealth <= 0)
        {
            currentHealth = 0;

        }
        LifeChanged.Invoke(currentHealth);
    }
}