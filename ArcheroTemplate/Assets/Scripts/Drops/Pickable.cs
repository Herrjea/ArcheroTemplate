using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour, IPickable
{
    [SerializeField] protected int amount;
    protected ResourceType type;

    protected Resource resource;


    public abstract void ResourceCollected();

    public abstract IEnumerator PickupAnimation();


    public int Amount
    {
        get => resource.amount;
    }

    public ResourceType Type
    {
        get => resource.type;
    }
}
