using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour, IDamaging, ICollisionEffect
{
    [SerializeField] protected float damage = 1;


    public void ApplyDamage(IDamageable target, Vector3 from)
    {
        target.ReceiveDamage(ComputeDamage(), from);
    }


    public void ApplyEffect(Collision collision)
    {
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();

        if (target != null)
            ApplyDamage(target, collision.GetContact(0).point);
    }


    protected virtual float ComputeDamage()
    {
        return damage;
    }
}
