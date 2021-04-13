using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityApplier : MonoBehaviour
{
    List<PlayerAbility> abilityPool;
    PlayerAbility selectedAbility;

    [HideInInspector] int highestUnlocked = 0;


    public static float projStrengthMultiplier = 1;


    void Awake()
    {
        abilityPool = new List<PlayerAbility>();

        for (int i = 0; i < highestUnlocked + 1; i++)
            foreach (PlayerAbility ability in Resources.LoadAll<PlayerAbility>("PlayerAbilities/" + i))
                abilityPool.Add(ability);

        print(abilityPool.Count + " abilities found");

        GameEvents.SubWaveFinished.AddListener(ApplyRandomAbility);
    }


    void ApplyRandomAbility(int wave, int subwave)
    {
        selectedAbility = abilityPool[Random.Range(0, abilityPool.Count)];
        print("Applying ability " + selectedAbility.name);

        switch (selectedAbility.attribute)
        {
            case AttrModifier.MaxHealth:
                GameEvents.NewMaxHealthAbility.Invoke(selectedAbility);
                
                break;

            case AttrModifier.ProjStrength:
                GameEvents.NewProjSptrengthAbility.Invoke(selectedAbility);
                projStrengthMultiplier *= selectedAbility.multiplier;
                break;

            case AttrModifier.ProjUp:
                GameEvents.NewProjUpAbility.Invoke(selectedAbility);
                projStrengthMultiplier *= selectedAbility.multiplier;
                break;
        }
    }
}
