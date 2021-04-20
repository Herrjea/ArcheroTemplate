using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyTypeInWave
{
    public GameObject enemy;
    public int amount = 1;

    public EnemyTypeInWave(GameObject enemy)
    {
        this.enemy = enemy;
    }
}

[System.Serializable]
public class SubWave
{
    public string name;
    public EnemyTypeInWave[] enemies;
    public float maxTimeUntilNextWave = 10;
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
        set => subWaves[index] = value;
    }

    public int Lenght
    {
        get => subWaves.Length;
    }
}


public class WaveSpawner : MonoBehaviour
{
    [SerializeField] protected Wave[] waves;
    protected int currentWave = 0;
    protected int currentSubWave = -1;

    [Tooltip("When there are this amount of active enemies or less, the next wave will be spawned")]
    [SerializeField] protected int minEnemyCountThreshold = 0;
    protected int enemiesOnScreen = 0;

    protected Coroutine spawnCoroutine = null;

    protected Vector2 roomSize;


    protected virtual void Awake()
    {
        GameEvents.EnemyDied.AddListener(EnemyDied);
        GameEvents.NewChosenAbility.AddListener(NewChosenAbility);

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

            //GameEvents.WaveFinished.Invoke(currentWave, currentSubWave);
        }

        if (currentWave < waves.Length)
        {
            if (spawnCoroutine != null)
                StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
    }

    void NewChosenAbility(PlayerAbility ability)
    {
        Spawn();
    }

    IEnumerator SpawnCoroutine()
    {
        print("Spawning wave " + currentWave + "." + currentSubWave);

        for (int i = 0; i < waves[currentWave][currentSubWave].enemies.Length; i++)
        {
            for (int j = 0; j < waves[currentWave][currentSubWave].enemies[i].amount; j++)
                InstantiateEnemy(waves[currentWave][currentSubWave].enemies[i].enemy);

            enemiesOnScreen += waves[currentWave][currentSubWave].enemies[i].amount;
        }

        if (waves[currentWave][currentSubWave].newMinThreshold >= 0)
            minEnemyCountThreshold = waves[currentWave][currentSubWave].newMinThreshold;

        // If there still are more subWaves in the current wave,
        // more enemies can be spawned before the remaining ones die
        if (currentSubWave < waves[currentWave].Lenght)
        {
            yield return new WaitForSeconds(waves[currentWave][currentSubWave].maxTimeUntilNextWave);
            //GameEvents.SubWaveFinished.Invoke(currentWave, currentSubWave);
        }
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
        enemiesOnScreen--;

        if (enemiesOnScreen == minEnemyCountThreshold)
        {
            GameEvents.SubWaveFinished.Invoke(currentWave, currentSubWave);
        }
        else if (enemiesOnScreen < minEnemyCountThreshold)
        {
            print("Argo raro pasa por ahí eh, perdona que te diga");
        }
    }
}
