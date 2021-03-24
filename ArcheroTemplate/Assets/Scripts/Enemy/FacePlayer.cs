using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FacePlayer : MonoBehaviour
{
    [SerializeField] protected float rotationSeekspeed = 0.1f;
    bool facingPlayer = true;

    Transform target;


    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        if (facingPlayer)
            RotateTowardsPlayer();
    }

    void RotateTowardsPlayer()
    {
        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(target.position - transform.position),
                rotationSeekspeed
            );
    }


    public bool FacingPlayer
    {
        set => facingPlayer = value;
    }
}
