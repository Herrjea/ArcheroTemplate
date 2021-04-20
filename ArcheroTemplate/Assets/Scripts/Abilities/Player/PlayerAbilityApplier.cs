using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityApplier : MonoBehaviour
{
    List<PlayerAbility> abilityPool;
    int[] selectedAbilities;

    [HideInInspector] int highestUnlocked = 0;


    public static float projStrengthMultiplier = 1;


    void Awake()
    {
        abilityPool = new List<PlayerAbility>();

        for (int i = 0; i < highestUnlocked + 1; i++)
            foreach (PlayerAbility ability in Resources.LoadAll<PlayerAbility>("PlayerAbilities/" + i))
                abilityPool.Add(ability);

        print(abilityPool.Count + " abilities found");

        GameEvents.SubWaveFinished.AddListener(SelectRandomAbilities);
        GameEvents.WaveFinished.AddListener(SelectRandomAbilities);

        GameEvents.NewChosenAbility.AddListener(ApplyChosenAbility);
    }


    void SelectRandomAbilities(int wave, int subwave)
    {
        selectedAbilities = new int[] { -1, -1, -1 };
        int newSelectedIndex;

        for (int i = 0; i < selectedAbilities.Length; i++)
        {
            do
            {
                newSelectedIndex = Random.Range(0, abilityPool.Count);
            } while (Contains(selectedAbilities, newSelectedIndex));
            selectedAbilities[i] = newSelectedIndex;
        }

        GameEvents.NewAbilitiesToChoose.Invoke(
            abilityPool[selectedAbilities[0]],
            abilityPool[selectedAbilities[1]],
            abilityPool[selectedAbilities[2]]
        );
    }

    void ApplyChosenAbility(PlayerAbility ability)
    {
        print("--------- Applying ability " + ability.name);

        switch (ability.attribute)
        {
            case AttrModifier.MaxHealth:
                GameEvents.NewMaxHealthAbility.Invoke(ability);
                
                break;

            case AttrModifier.ProjStrength:
                GameEvents.NewProjSptrengthAbility.Invoke(ability);
                projStrengthMultiplier *= ability.multiplier;
                GameEvents.NewPlayerStrengthValue.Invoke();
                break;

            case AttrModifier.ProjUp:
                GameEvents.NewProjUpAbility.Invoke(ability);
                projStrengthMultiplier *= ability.multiplier;
                GameEvents.NewPlayerStrengthValue.Invoke();
                break;
        }
    }


    bool Contains(int[] array, int value)
    {
        foreach (int i in array)
            if (i == value)
                return true;

        return false;
    }
}
