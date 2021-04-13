using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjDamageOnCollision : DamageOnCollision
{
    protected override float ComputeDamage()
    {
        return damage * PlayerAbilityApplier.projStrengthMultiplier;
    }
}
