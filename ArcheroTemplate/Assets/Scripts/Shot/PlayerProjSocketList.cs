using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjSocketList : ProjSocketList
{
    protected override void Awake()
    {
        base.Awake();

        // Only the player listens to shot input
        GameEvents.PlayerShot.AddListener(Shoot);
    }
}
