using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropOnDeath : MonoBehaviour
{
    [SerializeField] bool dropOnlyOne = true;
    [SerializeField] List<ItemToDrop> items;


    public void DropItem()
    {
        if (items.Count == 0)
            return;

        // Choose one item first,
        // then roll the dice.
        // Only one can come out
        if (dropOnlyOne)
        {
            ItemToDrop item = items[Random.Range(0, items.Count)];

            if (Random.value < item.probability)
                for (int i = 0; i < item.amount; i++)
                    GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        }

        // Roll the dice for each item.
        // All of them can come out
        else
        {
            foreach (ItemToDrop item in items)
                if (Random.value < item.probability)
                    for (int i = 0; i < item.amount; i++)
                        GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        }
    }
}
