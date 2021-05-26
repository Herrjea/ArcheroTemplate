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
            if (pickable.Type == ResourceType.Health)
                stats.ReceiveHealing(pickable.Amount);

            pickable.ResourceCollected();
        }
    }
}
