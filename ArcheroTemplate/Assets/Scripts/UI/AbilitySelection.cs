using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilitySelection : MonoBehaviour
{
    PlayerAbility[] abilities;
    TMP_Text ability1Name, ability2Name, ability3Name;
    GameObject panel;


    private void Awake()
    {
        abilities = new PlayerAbility[3];

        panel = transform.Find("Panel").gameObject;

        ability1Name = panel.transform.Find("Ability1").transform.Find("Ability1Name").GetComponent<TMP_Text>();
        ability2Name = panel.transform.Find("Ability2").transform.Find("Ability2Name").GetComponent<TMP_Text>();
        ability3Name = panel.transform.Find("Ability3").transform.Find("Ability3Name").GetComponent<TMP_Text>();

        panel.SetActive(false);

        GameEvents.NewAbilitiesToChoose.AddListener(NewAbilities);
    }


    public void NewAbilities(PlayerAbility newAbility1, PlayerAbility newAbility2, PlayerAbility newAbility3)
    {
        ability1Name.text = newAbility1.formattedName;
        ability2Name.text = newAbility2.formattedName;
        ability3Name.text = newAbility3.formattedName;

        abilities[0] = newAbility1;
        abilities[1] = newAbility2;
        abilities[2] = newAbility3;

        panel.SetActive(true);
    }

    public void AbilityChosen(int index)
    {
        GameEvents.NewChosenAbility.Invoke(abilities[index]);

        panel.SetActive(false);
    }
}
