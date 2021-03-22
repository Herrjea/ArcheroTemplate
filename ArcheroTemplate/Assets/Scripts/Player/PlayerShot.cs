using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    ProjSocketList sockets;

    bool shooting = false;
    Coroutine shootCoroutine = null;

    [SerializeField] float projectileSpeed = 1;
    Vector3 projectileVelocity = Vector3.forward;

    [SerializeField] float shotCD = 1;
    float CDRemaining = 0;

    [SerializeField] ObjectPool projPool;


    private void Awake()
    {
        sockets = transform.Find("ProjSockets").GetComponent<ProjSocketList>();

        projectileVelocity = projectileVelocity.normalized * projectileSpeed;

        GameEvents.StartShooting.AddListener(StartShooting);
        GameEvents.StopShooting.AddListener(StopShooting);
        GameEvents.ToggleShooting.AddListener(ToggleShooting);
    }

    private void Start()
    {
        StartShooting();
    }


    void StartShooting()
    {
        if (shootCoroutine == null)
            shootCoroutine = StartCoroutine(Shoot());
    }

    void StopShooting()
    {
        shooting = false;
    }

    void ToggleShooting()
    {
        if (shooting)
            StopShooting();
        else
            StartShooting();
    }


    IEnumerator Shoot()
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
                    null
                );

                CDRemaining = shotCD;
            }

            yield return null;
        }
    }
}
