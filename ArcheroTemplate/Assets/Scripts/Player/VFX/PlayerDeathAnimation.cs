using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAnimation : DeathAnimation
{
    protected override void Awake()
    {
        base.Awake();

        GameEvents.PlayerDied.AddListener(Play);
    }

    public override void Play()
    {
        // Prevent the death animation to be distorted by rotation,
        // in case the player dies while moving horizontally
        transform.rotation = Quaternion.identity;

        base.Play();
    }
}
