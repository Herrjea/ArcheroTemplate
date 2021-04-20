using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class IsolatedEnemyGroup
{
    public GameObject enemy;
    public int minAmount = 3;
    public int maxAmount = 5;

    [Tooltip("Not normalized. Prob of regular subWave is 1, and isolatedGroup probs will be added for later normalization.")]
    public float spawnProbability = .1f;
}


public class ProceduralWaveSpawner : WaveSpawner
{
    [SerializeField] int waveCount = 10;
    [SerializeField] int subwavesPerWave = 5;
    [SerializeField] int minEnemiesPerSubwave = 3;
    [SerializeField] int maxEnemiesPerSubwave = 6;

    [Tooltip("Amount of remaining enemies required to trigger the next wave")]
    [SerializeField] int maxEnemyThreshold = 2;

    [Tooltip("Enemies down the list will be considered harder and will only appear in later waves")]
    [SerializeField] GameObject[] enemyPool;

    [SerializeField] IsolatedEnemyGroup[] isolatedGroups;

    float errorMargin = .2f;


    protected override void Awake()
    {
        StartCoroutine(GenerateWaves());

        StartCoroutine(DelayedBaseAwake());
    }

    IEnumerator DelayedBaseAwake()
    {
        yield return new WaitForSeconds(1);

        base.Awake();
    }


    IEnumerator GenerateWaves()
    {
        waves = new Wave[waveCount];
        for (int i = 0; i < waveCount; i++)
            waves[i] = new Wave();

        foreach (Wave wave in waves)
            wave.subWaves = new SubWave[subwavesPerWave];

        //NormalizeProbabilities();

        for (int i = 0; i < waveCount; i++)
            for (int j = 0; j < subwavesPerWave; j++)
            {
                GenerateSubwave(i, j);
            }

        yield return null;
    }

    void GenerateSubwave(int wave, int subWave)
    {
        waves[wave][subWave] = new SubWave();

        waves[wave][subWave].enemies = new EnemyTypeInWave[Random.Range(minEnemiesPerSubwave, maxEnemiesPerSubwave)];

        for (int i = 0; i < waves[wave][subWave].enemies.Length; i++)
            waves[wave][subWave].enemies[i] = new EnemyTypeInWave(enemyPool[Random.Range(0, enemyPool.Length)]);

        waves[wave][subWave].newMinThreshold = Random.Range(0, maxEnemyThreshold + 1);
    }

    void NormalizeProbabilities()
    {
        float absoluteSum = 1;
        float normalizeFactor;

        foreach (IsolatedEnemyGroup group in isolatedGroups)
            absoluteSum += group.spawnProbability;

        normalizeFactor = 1.0f / absoluteSum;

        foreach (IsolatedEnemyGroup group in isolatedGroups)
            group.spawnProbability *= normalizeFactor;
    }
}
