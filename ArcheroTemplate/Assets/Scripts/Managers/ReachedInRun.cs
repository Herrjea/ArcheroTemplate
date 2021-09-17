using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedInRun : MonoBehaviour
{
    [HideInInspector] public int coins = 0;
    [HideInInspector] public int wave = 0;
    [HideInInspector] public int subwave = 0;


    void Awake()
    {
        GameEvents.CoinsGathered.AddListener(CoinsGathered);
        GameEvents.SubWaveFinished.AddListener(WavePassed);
    }


    void CoinsGathered(int amount = 1)
    {
        coins += amount;
    }

    void WavePassed(int wave, int subwave)
    {
        this.wave = wave;
        this.subwave = subwave;
    }
}
