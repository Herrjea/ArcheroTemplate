using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathManager : MonoBehaviour
{
    private void Awake()
    {
        GameEvents.EnemyDied.AddListener(EnemyDied);
    }


    public void EnemyDied(Vector3 position)
    {
        print("Enemy died at " + position);
    }
}
