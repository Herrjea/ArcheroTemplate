using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    BulletSocketList sockets;

    bool shooting = false;

    [SerializeField] float projectileSpeed = 1;
    Vector3 projectileVelocity = Vector3.forward;

    [SerializeField] float shotCD = 1;
    float CDRemaining = 0;

    public GameObject projectile;


    private void Awake()
    {
        sockets = transform.Find("BulletSockets").GetComponent<BulletSocketList>();

        projectileVelocity = projectileVelocity.normalized * projectileSpeed;
    }


    public void StartShooting()
    {
        StartCoroutine(Shoot());
    }

    public void StopShooting()
    {
        shooting = false;
    }


    IEnumerator Shoot()
    {
        // Prevent two shooting coroutines to run simultaneously
        if (!shooting)
        {
            shooting = true;

            while (shooting)
            {
                CDRemaining -= Time.deltaTime;

                if (CDRemaining <= 0)
                {
                    GameEvents.PlayerShot.Invoke(projectile, projectileVelocity);

                    CDRemaining = shotCD;
                }

                yield return null;
            }
        }
    }
}
