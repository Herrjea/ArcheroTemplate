using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerStats))]

public class DropPick : MonoBehaviour
{
    PlayerStats stats;


    void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }


    private void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.gameObject.GetComponent<IPickable>();

        if (pickable != null)
        {
            switch (pickable.Type)
            {
                case ResourceType.Health:
                    stats.ReceiveHealing(pickable.Amount);
                    break;
                case ResourceType.Money:
                    GameEvents.CoinsGathered.Invoke(10);
                    break;
                default:
                    print("Unknown resource type: " + pickable.Type);
                    break;
            }

            pickable.ResourceCollected();
        }
    }
}
