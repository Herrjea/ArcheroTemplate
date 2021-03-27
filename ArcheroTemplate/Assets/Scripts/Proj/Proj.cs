using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proj : MonoBehaviour
{
    [HideInInspector] protected Vector3 velocity;
    [HideInInspector] protected Transform target = null;

    [SerializeField] float lifetime = 5;


    protected abstract void FixedUpdate();


    private void OnCollisionEnter(Collision collision)
    {
        print("proj entered collision from " + collision.collider.name);

        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Invoke("Hide", lifetime);
    }

    void Hide()
    {
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
