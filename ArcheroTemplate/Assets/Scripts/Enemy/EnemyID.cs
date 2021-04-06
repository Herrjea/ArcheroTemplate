using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyID : MonoBehaviour
{
    public static int totalSpawned = 0;

    [HideInInspector] int id;


    public int ID
    {
        get => id;
    }


    public int SetID()
    {
        id = totalSpawned;

        totalSpawned++;

        return id;
    }
}
