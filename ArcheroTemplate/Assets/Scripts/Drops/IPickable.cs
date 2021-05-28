using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    int Amount { get; }
    ResourceType Type { get; }

    void ResourceCollected();

    IEnumerator PickupAnimation();
}
