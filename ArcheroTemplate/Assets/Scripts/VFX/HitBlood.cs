using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBlood : MonoBehaviour
{
    protected ParticleSystem bloodParticles;
    protected Transform bloodTransform;

    protected void Awake()
    {
        bloodTransform = transform.Find("VFX").Find("Blood");
        bloodParticles = bloodTransform.GetComponent<ParticleSystem>();
    }


    public void RotateTowards(Vector3 direction)
    {
        float angle = Vector3.SignedAngle(
            Vector3.right,
            direction,
            Vector3.up
        );

        bloodTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    public virtual void Play(Vector3 direction)
    {
        RotateTowards(direction);

        bloodParticles.Play();
    }
}
