using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct BossBehaviour
{
    public float healthRatioTrigger;
    public EnemyMovement movement;
    public EnemyShot shot;
}

public class BossBehaviourManager : MonoBehaviour
{
    [SerializeField] List<BossBehaviour> behaviours;
    int currentBehaviour = 0;

    float maxHealth;


    void Awake()
    {
        EnableBehaviour(0);

        for (int i = 1; i < behaviours.Count; i++)
            DisableBehaviour(i);
    }


    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }


    public void NewCurrentHealth(float currentHealth)
    {

        if (currentBehaviour < behaviours.Count - 1)
        {
            float healthRatio = currentHealth / maxHealth;

            if (healthRatio <= behaviours[currentBehaviour + 1].healthRatioTrigger)
            {
                DisableBehaviour(currentBehaviour);
                currentBehaviour++;
                EnableBehaviour(currentBehaviour);

                print("Changing " + gameObject.name + " behaviour to " + currentBehaviour);
            }
        }
    }


    void DisableBehaviour(int position)
    {
        behaviours[position].movement.enabled = false;
        behaviours[position].shot.enabled = false;
    }

    void EnableBehaviour(int position)
    {
        behaviours[position].movement.enabled = true;
        behaviours[position].shot.enabled = true;
    }
}
