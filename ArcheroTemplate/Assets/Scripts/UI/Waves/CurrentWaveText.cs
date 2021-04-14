using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TMP_Text))]

public class CurrentWaveText : MonoBehaviour
{
    TMP_Text textHolder;


    void Awake()
    {
        textHolder = GetComponent<TMP_Text>();

        GameEvents.SubWaveFinished.AddListener(ChangeText);

        ChangeText(0, 0);
    }


    void ChangeText(int wave, int subWave)
    {
        textHolder.text = $"{wave + 1}.{subWave + 1}";
    }
}
