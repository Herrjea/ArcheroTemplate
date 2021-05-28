using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int softCoins;

    //Talents (0 means talent unlocked)
    public int strengthTalentLevel; 
    public int powerTalentLevel;
    public int recoverTalentLevel;
    public int blockTalentLevel;
    public int ironBulwarkTalentLevel;
    public int agileTalentLevel;
    public int gloryTalentLevel;
    public int patrolEarningsTalentLevel;
    public int enhanceEquipmentTalentLevel;
    public int heroPowerupTalentLevel;
    public int hiddenTalentLevel;

    public SaveData()
    {
        softCoins = 100;
    }
}
