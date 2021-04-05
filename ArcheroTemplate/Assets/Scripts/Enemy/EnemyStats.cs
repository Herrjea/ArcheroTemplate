
using UnityEngine;


public class EnemyStats : Stats
{
    ColorBlink colorBlink;


    protected override void Awake()
    {
        base.Awake();

        colorBlink = GetComponent<ColorBlink>();
    }


    protected override void Die()
    {
        GameEvents.EnemyDied.Invoke(transform.position);

        deathAnimation.Play();
    }

    protected override void GotHit(float amount)
    {
        colorBlink.Blink();
    }
}
