using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;

    [SerializeField] float lifetime = 5;


    protected abstract void FixedUpdate();


    protected void OnTriggerEnter(Collider other)
    {
        print("projectile entered trigger from " + other.name);

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
}
