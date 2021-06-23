
using System.Diagnostics;
using UnityEngine;


[RequireComponent(typeof(ColorBlink))]
[RequireComponent(typeof(DropOnDeath))]
[RequireComponent(typeof(Dissolve))]

public class EnemyStats : Stats
{
    protected ColorBlink colorBlink;
    protected DropOnDeath dropOnDeath;
    protected Dissolve dissolve;


    protected override void Awake()
    {
        base.Awake();

        colorBlink = GetComponent<ColorBlink>();
        dropOnDeath = GetComponent<DropOnDeath>();
        dissolve = GetComponent<Dissolve>();

        dissolve.StartDissolve();
    }

    public override void Die(bool playAnimation = true)
    {
        GameEvents.EnemyDied.Invoke(transform.position);

        dropOnDeath.DropItem();

        //print("EnemyStats::Die from " + name + ", called by " + new StackFrame(1, true).GetMethod().Name);
        //UnityEngine.Debug.Break();

        if (playAnimation)
            deathAnimation.Play();
        else
            Destroy(gameObject);
    }

    protected override void GotHit(float amount)
    {
        colorBlink.Blink();
    }
}
