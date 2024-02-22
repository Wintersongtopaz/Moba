using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    // Where to spawn this wave
    [SerializeField] public Vector3 spawnPoint;
    // Which path the units will follow
    [SerializeField] public NavPath path;
    // which wave to spawn
    [SerializeField] public UnitWave wave;
}
//Unit Spawner: A Mono Behavior component used to spawn unit waves at regular intervals
public class UnitSpawner : MonoBehaviour
{
    public List<Wave> waves;

    void Start()
    {
        foreach(Wave wave in waves)
        {
            StartCoroutine(SpawnWave(wave));
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        yield return new WaitForSeconds(wave.wave.spawnDelay);

        while (true)
        {
            foreach(GameObject prefab in wave.wave.prefabs)
            {
                GameObject unit = Instantiate(prefab, wave.spawnPoint, Quaternion.identity, transform);
                unit.GetComponent<FollowPath>().path = wave.path;
                yield return new WaitForSeconds(wave.wave.spawnDelay);
            }
            yield return new WaitForSeconds(wave.wave.spawnInterval);
        }
    }
}
