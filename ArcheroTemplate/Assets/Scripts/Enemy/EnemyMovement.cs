using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float seekSpeed = 1;
    protected Transform target;
    protected bool seeking = false;


    protected void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
}
