using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjSocketList : ProjSocketList
{
    protected override void Awake()
    {
        base.Awake();

        GameEvents.NewProjUpAbility.AddListener(ProjUpAbility);

        // Only the player listens to shot input
        GameEvents.PlayerShot.AddListener(Shoot);
    }


    void ProjUpAbility(PlayerAbility ability)
    {
        if (ability.socketPosition == SocketPosition.BothSides)
        {
            MoreProjs(SocketPosition.Left);
            MoreProjs(SocketPosition.Right);
        }
        else
        {
            MoreProjs(ability.socketPosition);
        }
    }
}
