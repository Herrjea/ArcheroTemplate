using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shot
{
    protected override void Awake()
    {
        base.Awake();

        sockets = transform.Find("PlayerProjSockets").GetComponent<ProjSocketList>();
    }

    protected override void Start()
    {
        GameEvents.StartShooting.AddListener(StartShooting);
        GameEvents.StopShooting.AddListener(StopShooting);
        GameEvents.ToggleShooting.AddListener(ToggleShooting);

        GameEvents.PlayerDied.AddListener(StopShooting);

        base.Start();
    }

    protected override IEnumerator Shoot(Transform target)
    {
        shooting = true;

        while (shooting)
        {
            CDRemaining -= Time.deltaTime;

            if (CDRemaining <= 0)
            {
                GameEvents.PlayerShot.Invoke(
                    projPool,
                    projVelocity,
                    target,
                    true
                );

                CDRemaining = shotCD;
            }

            yield return null;
        }
    }
}
