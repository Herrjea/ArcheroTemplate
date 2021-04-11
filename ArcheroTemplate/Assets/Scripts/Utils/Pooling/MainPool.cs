using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPool : MonoBehaviour
{
    public List<Poolable> FreeObjectsWithName(string name)
    {
        List<Poolable> found = new List<Poolable>();
        Poolable poolable;

        foreach (Transform child in transform)
        {
            poolable = child.GetComponent<Poolable>();
            if (child.name.Equals(name) && poolable.isFree)
                found.Add(poolable);
        }

        return found;
    }
}
