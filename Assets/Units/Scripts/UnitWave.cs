using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Unit Wave: A Scriptable Object used to represent types of waves and their properties
[CreateAssetMenu()]
public class UnitWave : ScriptableObject
{
    // Units to spawn
    public List<GameObject> prefabs;
    // Time before first wave
    public float startDelay = 2f;
    // Time between units spawned
    public float spawnDelay = 0.2f;
    // Time between waves
    public float spawnInterval = 10f;

}
