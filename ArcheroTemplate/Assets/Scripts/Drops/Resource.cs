using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource
{
    public ResourceType type;
    public int amount = 1;

    public Resource(ResourceType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }
}
