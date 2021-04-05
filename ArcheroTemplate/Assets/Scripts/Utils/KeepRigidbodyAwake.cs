using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRigidbodyAwake : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }
}
