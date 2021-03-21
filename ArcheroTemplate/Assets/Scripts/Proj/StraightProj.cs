using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProj : Proj
{
    protected override void FixedUpdate()
    {
        transform.Translate(velocity);
    }
}
