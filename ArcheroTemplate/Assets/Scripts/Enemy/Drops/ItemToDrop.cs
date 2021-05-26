using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public struct ItemToDrop
{
    public GameObject prefab;
    public float probability;
    public int amount;
}
