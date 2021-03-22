using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : Shot
{
    protected override void Awake()
    {
        base.Awake();

        sockets = transform.Find("ProjSockets").GetComponent<ProjSocketList>();
    }

    protected override IEnumerator Shoot(Transform target)
    {
        shooting = true;

        while (shooting)
        {
            CDRemaining -= Time.deltaTime;

            if (CDRemaining <= 0)
            {
                sockets.Shoot(
                    projPool,
                    projectileVelocity,
                    target
                );

                CDRemaining = shotCD;
            }

            yield return null;
        }
    }
}
