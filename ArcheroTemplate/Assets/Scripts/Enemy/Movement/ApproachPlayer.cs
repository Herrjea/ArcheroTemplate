using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    float velocityMagnitude;

    Transform player;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    private void LateUpdate()
    {
        
        transform.position +=
            (player.position - transform.position).normalized
            *
            speed
            *
            Time.deltaTime;
        /*

        velocityMagnitude = (player.position - transform.position).magnitude;

        transform.position =
            Vector3.Lerp(
                transform.position,
                player.position,
                seekSpeed * Time.deltaTime
            );*/
    }
}
