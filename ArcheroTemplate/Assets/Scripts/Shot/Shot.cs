using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ObjectPool))]

public class Shot : MonoBehaviour
{
    protected ProjSocketList sockets;

    protected bool shooting = false;
    protected Coroutine shootCoroutine = null;

    [SerializeField] protected float projSpeed = 1;
    protected Vector3 projVelocity;
    protected Transform target = null;

    [SerializeField] protected float shotCD = 1;
    protected float CDRemaining = 0;

    [SerializeField] protected ObjectPool projPool;


    protected virtual void Awake()
    {
        projVelocity = transform.forward * projSpeed;
    }

    protected virtual void Start()
    {
        StartShooting();
    }


    protected void StartShooting()
    {
        if (shootCoroutine == null)
            shootCoroutine = StartCoroutine(Shoot(target));
    }

    protected void StopShooting()
    {
        shooting = false;
    }

    protected void ToggleShooting()
    {
        if (shooting)
            StopShooting();
        else
            StartShooting();
    }


    protected virtual IEnumerator Shoot(Transform target)
    {
        Debug.Log("Unimplemented Shot::Shoot coroutine");

        return null;
    }


    public Transform Target
    {
        set => target = value;
    }
}
