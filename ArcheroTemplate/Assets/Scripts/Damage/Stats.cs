using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 10;
    [SerializeField] protected float defense = 1;

    [SerializeField] float currentHealth;


    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }


    public void ReceiveDamage(float amount, DamageType type = DamageType.Physical)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            Die();
        else
            GotHit(amount);
    }


    protected virtual void Die()
    {
        Debug.Log("Unimplemented Stats::Die member on object " + gameObject.name);
    }

    protected virtual void GotHit(float amount)
    {
        Debug.Log("Unimplemented Stats::GotHit member on object " + gameObject.name);
    }
}
