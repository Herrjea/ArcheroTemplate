using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Explode))]

public class ExplodeOnCollision : MonoBehaviour, ICollisionEffect
{
    [SerializeField] float damage = 3;
    [SerializeField] float radius = 3;

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
        print(Convert.ToString(collision.collider.gameObject.layer & layerMask, 2).PadLeft(32, '0'));
        print(Convert.ToString(layerMask, 2).PadLeft(32, '0'));

        print(Convert.ToString(collision.collider.gameObject.layer, 2).PadLeft(32, '0'));

        if ((collision.collider.gameObject.layer & layerMask) > 0)
        {
            model.SetActive(false);

            explode.Trigger(damage, radius);
        }
    }

}
