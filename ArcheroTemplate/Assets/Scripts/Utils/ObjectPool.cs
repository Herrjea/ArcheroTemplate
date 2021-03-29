using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [SerializeField] int poolSize;
    int current;
    GameObject[] gameObjectsPool;

    // Needed for UI elements to be rendered
    [SerializeField] bool makeChildrenOfSelf = false;


    void Awake()
    {
        gameObjectsPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            gameObjectsPool[i] = Instantiate(
                objectToPool,
                transform.position,
                Quaternion.identity,
                makeChildrenOfSelf ? transform : transform.parent
            );
            gameObjectsPool[i].SetActive(false);

            // Useful for UI elements, to prevent
            // the pooled items to be rendered
            // above what was already there
            gameObjectsPool[i].transform.SetAsFirstSibling();
        }
    }

    public GameObject GetNext()
    {
        current = ++current % poolSize;

        gameObjectsPool[current].SetActive(false);
        gameObjectsPool[current].SetActive(true);

        return gameObjectsPool[current];
    }


    public int Size
    {
        get => poolSize;
    }
}