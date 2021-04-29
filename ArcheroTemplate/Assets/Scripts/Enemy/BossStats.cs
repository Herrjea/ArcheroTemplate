using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossBehaviourManager))]

public class BossStats : EnemyStats
{
    BossBehaviourManager bossBehaviour;


    protected override void Awake()
    {
        base.Awake();

        bossBehaviour = GetComponent<BossBehaviourManager>();
        bossBehaviour.SetMaxHealth(maxHealth);
    }


    protected override void GotHit(float amount)
    {
        base.GotHit(amount);

        bossBehaviour.NewCurrentHealth(currentHealth);
    }
}
