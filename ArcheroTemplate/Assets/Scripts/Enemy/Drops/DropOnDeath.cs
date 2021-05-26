using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropOnDeath : MonoBehaviour
{
    [SerializeField] List<ItemToDrop> items;


    public void DropItem()
    {
        if (items.Count == 0)
            return;

        ItemToDrop item = items[Random.Range(0, items.Count)];

        if (Random.value < item.probability)
            for (int i = 0; i < item.amount; i++)
                GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
    }
}
