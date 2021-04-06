
using System.Diagnostics;


public class EnemyStats : Stats
{
    ColorBlink colorBlink;


    protected override void Awake()
    {
        base.Awake();

        colorBlink = GetComponent<ColorBlink>();
    }


    public override void Die(bool playAnimation = true)
    {
        GameEvents.EnemyDied.Invoke(transform.position);

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
