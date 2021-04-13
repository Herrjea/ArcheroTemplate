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
public class SubWave
{
    public string name;
    public EnemyTypeInWave[] enemies;
    public float maxTimeUntilNextWave = 20;
    public int newMinThreshold = -1;
}

[System.Serializable]
public class Wave
{
    public string name;
    public SubWave[] subWaves;

    public SubWave this[int index]
    {
        get => subWaves[index];
    }

    public int Lenght
    {
        get => subWaves.Length;
    }
}


public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    int currentWave = 0;
    int currentSubWave = -1;

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
        if (currentWave == waves.Length)
            return;

        currentSubWave++;
        if (currentSubWave == waves[currentWave].Lenght)
        {
            currentWave++;
            currentSubWave = 0;
        }

        if (currentWave < waves.Length)
        {
            if (spawnCoroutine != null)
                StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < waves[currentWave][currentSubWave].enemies.Length; i++)
        {
            for (int j = 0; j < waves[currentWave][currentSubWave].enemies[i].amount; j++)
                InstantiateEnemy(waves[currentWave][currentSubWave].enemies[i].enemy);
        }

        if (waves[currentWave][currentSubWave].newMinThreshold >= 0)
            minEnemyCountThreshold = waves[currentWave][currentSubWave].newMinThreshold;

        GameEvents.SubWaveFinished.Invoke(currentWave, currentSubWave);

        yield return new WaitForSeconds(waves[currentWave][currentSubWave].maxTimeUntilNextWave);

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
