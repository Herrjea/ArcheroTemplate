using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffectApplier : MonoBehaviour
{
    ICollisionEffect[] collisionEffects;


    private void Awake()
    {
        collisionEffects = GetComponents<ICollisionEffect>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer != gameObject.layer)
            foreach (ICollisionEffect effect in collisionEffects)
                effect.ApplyEffect(collision);
    }
}
