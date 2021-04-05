using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FacePlayer : EnemyRotation
{
    Transform target;


    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }


    protected override void ComputeLookRotation()
    {
        lookRotation = target.position - transform.position;
    }
}
