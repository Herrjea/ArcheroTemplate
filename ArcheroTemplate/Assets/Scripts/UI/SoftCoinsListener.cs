using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoftCoinsListener : MonoBehaviour
{

    TextMeshProUGUI softCoinsText;

    private void Awake()
    {
        softCoinsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        softCoinsText.text = SaveDataController.GetSoftCoins().ToString();
    }
}
