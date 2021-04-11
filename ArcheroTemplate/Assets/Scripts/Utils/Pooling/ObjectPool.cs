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

    MainPool mainPool;


    void Awake()
    {
        gameObjectsPool = new GameObject[poolSize];

        mainPool = GameObject.FindGameObjectWithTag("ObjPool").GetComponent<MainPool>();

        List<Poolable> poolables = mainPool.FreeObjectsWithName(objectToPool.name);
        if (poolables.Count < poolSize)
            InstantiateNew();
        else
            ReuseOld(poolables);
    }

    void InstantiateNew()
    {
        for (int i = 0; i < poolSize; i++)
        {
            gameObjectsPool[i] = Instantiate(
                objectToPool,
                transform.position,
                Quaternion.identity,
                makeChildrenOfSelf ?
                    transform
                    :
                    mainPool.transform
            );
            gameObjectsPool[i].SetActive(false);
            gameObjectsPool[i].name = objectToPool.name;

            // Useful for UI elements, to prevent
            // the pooled items to be rendered
            // above what was already there
            gameObjectsPool[i].transform.SetAsFirstSibling();
        }
    }

    void ReuseOld(List<Poolable> poolables)
    {
        for (int i = 0; i < poolSize; i++)
        {
            poolables[i].SetFree(false);
            gameObjectsPool[i] = poolables[i].gameObject;
            gameObjectsPool[i].transform.position = transform.position;
            gameObjectsPool[i].transform.rotation = Quaternion.identity;
            gameObjectsPool[i].SetActive(false);
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


    private void OnDestroy()
    {
        foreach (GameObject objectInPool in gameObjectsPool)
            objectInPool.GetComponent<Poolable>()?.SetFree();
    }
}