using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    ParticleSystem explosionParticles;

    [SerializeField] float explosionDuration = 1;
    [SerializeField] AnimationCurve particleSizeEase = AnimationCurve.EaseInOut(0, 0, 1, 1);

    Coroutine explosionCoroutine = null;

    Shot shot;
    NPCMovement movement;


    void Awake()
    {
        explosionParticles = transform.Find("VFX").Find("Explosion").GetComponent<ParticleSystem>();

        shot = GetComponent<Shot>();
        movement = GetComponent<NPCMovement>();
    }


    public void Trigger(float damage, float radius)
    {
        if (explosionCoroutine == null)
        {
            explosionCoroutine = StartCoroutine(ExplosionAnimation(damage, radius));

            /////////// daño en área
        }
    }

    IEnumerator ExplosionAnimation(float damage, float radius)
    {
        // Prevent the object from further acting
        shot?.StopShooting();
        movement?.StopMoving();

        float elapsed = 0;

        ParticleSystem.MainModule main = explosionParticles.main;
        main.startSize = radius;

        explosionParticles.Play();

        while (elapsed < explosionDuration)
        {
            elapsed += Time.deltaTime;

            main.startSize = Mathf.Lerp(
                radius,
                0,
                particleSizeEase.Evaluate(elapsed / explosionDuration)
            );

            print(elapsed / explosionDuration);

            yield return null;
        }

        explosionParticles.Stop();

        Destroy(gameObject);
    }
}
