using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proj : MonoBehaviour
{
    [HideInInspector] protected Vector3 velocity;
    [HideInInspector] protected Transform target = null;

    [SerializeField] float lifetime = 5;

    ParticleSystem contactExplosion;
    float explosionDuration = 0;
    GameObject model;


    protected void Awake()
    {
        contactExplosion = transform.Find("OnContact")?.GetComponentInChildren<ParticleSystem>();
        if (contactExplosion != null)
            explosionDuration = contactExplosion.main.duration;

        model = transform.Find("Model").gameObject;
    }


    protected abstract void FixedUpdate();


    protected void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(OnExplosion());
    }


    protected void OnEnable()
    {
        Invoke("Hide", lifetime);
    }

    protected void Hide()
    {
        gameObject.SetActive(false);
    }


    protected virtual IEnumerator OnExplosion()
    {
        velocity = Vector3.zero;
        model.SetActive(false);

        contactExplosion.Play();
        yield return new WaitForSeconds(explosionDuration);

        model.SetActive(true);
        gameObject.SetActive(false);
    }


    public Vector3 Velocity
    {
        set => velocity = value;
    }

    public Transform Target
    {
        set
        {
            if (value != null)
            {
                float speed = velocity.magnitude;
                velocity =
                    (target.position - transform.position).normalized
                    *
                    speed;
            }
        }
    }
}
