using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fake interface heheh

public class Poolable : MonoBehaviour
{
    [HideInInspector] public bool isFree = false;


    public void SetFree(bool value = true)
    {
        isFree = value;
    }
}
