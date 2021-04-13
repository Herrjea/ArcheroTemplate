using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerAbility", fileName = "NewPlayerAbility")]

public class PlayerAbility : ScriptableObject
{
    public AttrModifier attribute;
    public float multiplier = 1.2f;
}
