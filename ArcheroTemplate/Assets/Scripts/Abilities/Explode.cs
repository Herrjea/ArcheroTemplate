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
    NPCMovement[] movements;


    void Awake()
    {
        explosionParticles = transform.Find("VFX").Find("Explosion").GetComponent<ParticleSystem>();

        shot = GetComponent<Shot>();
        movements = GetComponents<NPCMovement>();
    }


    public void Trigger(float damage, float radius, Vector3 contactPoint, float pushForce)
    {
        if (explosionCoroutine == null)
        {
            explosionCoroutine = StartCoroutine(ExplosionAnimation(damage, radius));

            ApplyEffect(damage, radius, contactPoint, pushForce);
        }
    }

    IEnumerator ExplosionAnimation(float damage, float radius)
    {
        // Prevent the object from further acting
        shot?.StopShooting();
        foreach(NPCMovement movement in movements)
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

            yield return null;
        }

        explosionParticles.Stop();

        Destroy(gameObject);
    }


    void ApplyEffect(float damage, float radius, Vector3 contactPoint, float pushForce)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // On others (damage and push)
        foreach (Collider collider in colliders)
        {
            collider.gameObject.GetComponent<IDamageable>()?.ReceiveDamage(damage, transform.position);

            collider.gameObject.GetComponent<IPushable>()?.ReceivePushForce(pushForce, transform.position, radius);
        }

        // On self (only push)
        GetComponent<IPushable>()?.ReceivePushForce(pushForce, contactPoint, radius);
    }
}
