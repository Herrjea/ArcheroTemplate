using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentsController : MonoBehaviour
{
    [SerializeField] private Image[] _talents;
    void Start()
    {
        RefreshTalents();
    }

    private void RefreshTalents()
    {
        for (int i = 0; i < _talents.Length; i++)
        {
            if (TalentDataController.GetTalentData(i))
            {
                _talents[i].color = Color.white;
            }
        }
    } 

    public void UnlockTalents()
    {
        
        if (EconomyDataController.GetSoftCoins()>=100)
        {
            EconomyDataController.SetSoftCoins(EconomyDataController.GetSoftCoins()-100);
            int randomTalent = 0;
            do
            {
                 randomTalent = Random.Range(0, _talents.Length);
            }
            while (TalentDataController.GetTalentData(randomTalent));
            TalentDataController.SetTalentData(randomTalent, true);
            RefreshTalents();
        }
    }
    void Update()
    {
        
    }
}
