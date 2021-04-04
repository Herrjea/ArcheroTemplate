using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Explode))]

public class ExplodeOnCollision : MonoBehaviour, ICollisionEffect
{
    [SerializeField] float damage = 3;
    [SerializeField] float radius = 3;
    [SerializeField] float pushForce = 4000;

    [SerializeField] LayerMask layerMask;

    Explode explode;
    GameObject model;


    void Awake()
    {
        explode = GetComponent<Explode>();

        model = transform.Find("Model").gameObject;
    }


    public void ApplyEffect(Collision collision)
    {
        /*
         * Usually layer <n> is represented as <1 << n>,
         * but in collision.collider.gameObject.layer it's represented as simply <n>,
         * that's why I'm checking for <1 << layer> instead of just for <layer>
         * against the specified layerMask
         */

        if ((1 << collision.collider.gameObject.layer & layerMask) > 0)
        {
            model.SetActive(false);

            explode.Trigger(damage, radius, collision.GetContact(0).point, pushForce);
        }
    }

}
