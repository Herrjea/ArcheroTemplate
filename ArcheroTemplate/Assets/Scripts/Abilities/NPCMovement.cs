using UnityEngine;

public class NPCMovement : MonoBehaviour, IPushable
{
    protected bool isMoving = true;
    protected Rigidbody rb;

    // Randomization amount for certain variables in subclasses
    protected float errorMargin = 0.15f;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void StartMoving()
    {
        isMoving = true;
    }

    public virtual void StopMoving()
    {
        isMoving = false;
    }


    public void ReceivePushForce(float strength, Vector3 from, float radius)
    {
        rb?.AddExplosionForce(strength, from, radius);
    }
}
