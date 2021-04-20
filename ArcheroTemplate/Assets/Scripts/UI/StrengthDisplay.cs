using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrengthDisplay : MonoBehaviour
{
    TMP_Text textHolder;


    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();

        GameEvents.NewPlayerStrengthValue.AddListener(ChangeText);
    }


    void ChangeText()
    {
        textHolder.text = $"strength: {PlayerAbilityApplier.projStrengthMultiplier.ToString("F2")}";
    }
}
