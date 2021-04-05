using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorBlink : ColorBlink
{
    protected override void Awake()
    {
        base.Awake();

        GameEvents.PlayeGotHit.AddListener(OnGotHit);
    }
}
