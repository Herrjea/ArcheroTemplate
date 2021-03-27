using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 10;
    [SerializeField] protected float defense = 1;
    float currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void ReceiveDamage(float amount, DamageType type = DamageType.Physical)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            Die();
    }


    protected virtual void Die()
    {
        Debug.Log("Unimplemented Stats::Die member on object " + gameObject.name);
    }
}
