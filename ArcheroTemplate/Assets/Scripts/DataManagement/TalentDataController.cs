using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentDataController
{
    // public static int GetStrengthTalentLevel()
    // {
    //     Check();
    //     return GetData().strengthTalentLevel;
    // }
    // public static void SetStrengthTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().strengthTalentLevel= newValue;
    //     Save();
    // }
    //
    // public static int GetPowerTalentLevel()
    // {
    //     Check();
    //     return GetData().powerTalentLevel;
    // }
    // public static void SetPowerTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().strengthTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetRecoverTalentLevel()
    // {
    //     Check();
    //     return GetData().recoverTalentLevel;
    // }
    // public static void SetRecoverTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().recoverTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetBlockTalentLevel()
    // {
    //     Check();
    //     return GetData().blockTalentLevel;
    // }
    // public static void SetBlockTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().blockTalentLevel= newValue;
    //     Save();
    // }
    //
    // public static int GetIronBulwarkTalentLevel()
    // {
    //     Check();
    //     return GetData().ironBulwarkTalentLevel;
    // }
    // public static void SetIronBulwarkTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().ironBulwarkTalentLevel= newValue;
    //     Save();
    // }
    //
    // public static int GetAgileTalentLevel()
    // {
    //     Check();
    //     return GetData().agileTalentLevel;
    // }
    // public static void SetAgileTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().ironBulwarkTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetGloryTalentLevel()
    // {
    //     Check();
    //     return GetData().gloryTalentLevel;
    // }
    // public static void SetGloryTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().gloryTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetPatrolEarningsTalentLevel()
    // {
    //     Check();
    //     return GetData().patrolEarningsTalentLevel;
    // }
    // public static void SetPatrolEarningsTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().patrolEarningsTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetEnhanceEquipmentTalentLevel()
    // {
    //     Check();
    //     return GetData().enhanceEquipmentTalentLevel;
    // }
    // public static void SetEnhanceEquipmentTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().enhanceEquipmentTalentLevel = newValue;
    //     Save();
    // }
    //
    // public static int GetHeroPowerUpTalentLevel()
    // {
    //     Check();
    //     return GetData().heroPowerupTalentLevel;
    // }
    // public static void SetHeroPowerUpTTalentLevel(int newValue)
    // {
    //     Check();
    //     GetData().heroPowerupTalentLevel = newValue;
    //     Save();
    // }

    public static bool GetTalentData(int talent)
    {
        Check();
        return GetData().talents[talent];
    }
    public static void SetTalentData(int talent, bool newValue)
    {
        Check();
        GetData().talents[talent] = newValue;
        Save();
    }
    static SaveData GetData()
    {
        return SaveDataController.saveData;
    }
    static void Check()
    {
        SaveDataController.CheckInitialized();
    }
    static void Save()
    {
        SaveDataController.SaveToFile();
    }
}
