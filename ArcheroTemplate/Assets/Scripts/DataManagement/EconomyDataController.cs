using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyDataController
{
    public static int GetSoftCoins()
    {
        Check();
        return GetData().softCoins;
    }
    public static void SetSoftCoins(int newValue)
    {
        Check();
        GetData().softCoins = newValue;
        Save();
    }
    
    static void Check()
    {
        SaveDataController.CheckInitialized();
    }
    static void Save()
    {
        SaveDataController.SaveToFile();
    }
    static SaveData GetData()
    {
        return SaveDataController.saveData;
    }
}
