using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickable : Pickable
{
    private void Awake()
    {
        resource = new Resource(ResourceType.Money, amount);
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
