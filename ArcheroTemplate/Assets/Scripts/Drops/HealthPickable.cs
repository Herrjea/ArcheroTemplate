using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : Pickable
{
    private void Awake()
    {
        resource = new Resource(ResourceType.Health, amount);
    }

    public override void ResourceCollected()
    {
        StartCoroutine(PickupAnimation());
    }

    public override IEnumerator PickupAnimation()
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }
}
