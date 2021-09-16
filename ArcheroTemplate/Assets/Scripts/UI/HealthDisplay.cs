using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TMP_Text textHolder;


    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();

        GameEvents.NewPlayerHealthValues.AddListener(ChangeText);

        Empty();
    }


    void Empty()
    {
        textHolder.text = "";
    }


    void ChangeText(float current, float max)
    {
        textHolder.text = $"HP: {(int)current}/{(int)max}";
    }
}
