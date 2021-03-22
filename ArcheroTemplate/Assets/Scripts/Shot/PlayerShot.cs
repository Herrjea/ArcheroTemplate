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
        print("PlayeShot start. " + gameObject.name);

        GameEvents.StartShooting.AddListener(StartShooting);
        GameEvents.StopShooting.AddListener(StopShooting);
        GameEvents.ToggleShooting.AddListener(ToggleShooting);

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
                    projectileVelocity,
                    target
                );

                CDRemaining = shotCD;
            }

            yield return null;
        }
    }
}
