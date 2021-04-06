using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyTypeInWave
{
    public GameObject enemy;
    public int amount = 1;
}

[System.Serializable]
public class Wave
{
    public string name;
    public EnemyTypeInWave[] enemies;
    public float maxTimeUntilNextWave = 20;
    public int newMinThreshold = -1;
}


public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    int currentWave = -1;

    [Tooltip("When there are this amount of active enemies or less, the next wave will be spawned")]
    [SerializeField] int minEnemyCountThreshold = 0;
    int enemiesOnScreen = 0;

    Coroutine spawnCoroutine = null;

    Vector2 roomSize;


    void Awake()
    {
        GameEvents.EnemyDied.AddListener(EnemyDied);

        roomSize = Room.RoomSize;

        Spawn();
    }


    void Spawn()
    {
        currentWave++;

        if (currentWave < waves.Length)
        {
            if (spawnCoroutine != null)
                StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < waves[currentWave].enemies.Length; i++)
        {
            for (int j = 0; j < waves[currentWave].enemies[i].amount; j++)
                InstantiateEnemy(waves[currentWave].enemies[i].enemy);
        }

        if (waves[currentWave].newMinThreshold >= 0)
            minEnemyCountThreshold = waves[currentWave].newMinThreshold;

        yield return new WaitForSeconds(waves[currentWave].maxTimeUntilNextWave);

        Spawn();
    }

    void InstantiateEnemy(GameObject enemy)
    {
        GameObject newEnemy = GameObject.Instantiate(
                enemy,
                new Vector3(
                    Random.Range(-roomSize.x, roomSize.x) / 2.3f,
                    0,
                    Random.Range(0, roomSize.y) / 2.3f
                ),
                Quaternion.identity,
                transform
            );

        newEnemy.name = enemy.name + "." + newEnemy.GetComponent<EnemyID>().SetID();
    }


    void EnemyDied(Vector3 position)
    {
        enemiesOnScreen = transform.childCount - 1;

        if (enemiesOnScreen <= minEnemyCountThreshold)
            Spawn();
    }
}
