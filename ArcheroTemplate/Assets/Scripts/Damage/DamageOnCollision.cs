using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour, IDamaging
{
    [SerializeField] float damage = 3;


    private void OnCollisionEnter(Collision collision)
    {
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();

        if (target != null && collision.collider.gameObject.layer != gameObject.layer)
            ApplyDamage(target, collision.GetContact(0).point);
    }


    public void ApplyDamage(IDamageable target, Vector3 from)
    {
        target.ReceiveDamage(damage, from);
    }
}
