using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;


public class Life : MonoBehaviour
{
    [Header("Life Events")]
    [SerializeField] private UnityEvent<float> LifeChanged;
    [SerializeField] private UnityEvent LifeEnded;

    [Header("Stats")]
    [SerializeField] private float currentHealth;

    [Header("Object References")]
    [SerializeField] private Entity entity;

    private bool canBeDamaged = true;


    private void Start()
    {
        currentHealth = entity.maxLife;
    }

    public void TakeDamage(float damage)
    {
        if (!canBeDamaged) return;
        StartCoroutine(DamageSequence(damage));
    }

    private IEnumerator DamageSequence(float damage)
    {
        canBeDamaged = false;
        currentHealth = currentHealth - (damage - (damage * entity.defense / 100));

        if (currentHealth <= 0)
        {
            currentHealth = 0;

        }

        LifeChanged.Invoke(currentHealth);
        yield return new WaitForSeconds(entity.immuneFrames);
        canBeDamaged = true;

        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}