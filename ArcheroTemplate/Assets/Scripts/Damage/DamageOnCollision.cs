using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour, IDamaging
{
    [SerializeField] float damage = 3;


    private void OnCollisionEnter(Collision collision)
    {
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();

        if (target != null)
            ApplyDamage(target);
    }


    public void ApplyDamage(IDamageable target)
    {
        target.ReceiveDamage(damage);
    }
}
