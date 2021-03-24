using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float seekSpeed = .1f;
    protected Transform player;
    protected bool seeking = false;

    protected Vector2 roomSize = new Vector2(10, 15);


    protected void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
}
