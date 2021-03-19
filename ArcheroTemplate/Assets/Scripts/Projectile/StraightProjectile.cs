using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : Projectile
{
    protected override void FixedUpdate()
    {
        transform.Translate(velocity);
    }
}
