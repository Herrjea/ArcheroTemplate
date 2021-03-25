using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{
    [SerializeField] protected float health = 10;
    [SerializeField] protected float defense = 1;


    public void Damage(float amount, DamageType type = DamageType.Physical)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }


    protected virtual void Die()
    {
        Debug.Log("Unimplemented Stats::Die member");
    }
}
