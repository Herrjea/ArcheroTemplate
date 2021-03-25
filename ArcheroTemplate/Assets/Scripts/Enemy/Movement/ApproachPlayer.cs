using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : MonoBehaviour
{
    [SerializeField] float speed = 2;

    Transform player;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    private void FixedUpdate()
    {
        transform.position +=
            (player.position - transform.position).normalized
            *
            speed
            *
            Time.deltaTime;
    }
}
