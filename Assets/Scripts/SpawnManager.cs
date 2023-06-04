using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>SpawnManager</c> handles the spawn of objects on screen
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform _parentGameObject;

    // Spawn position
    private float _spawnPositionXRange = 8f;
    private float _spawnPositionY = 6f;
    private float _spawnPositionZ = 0f;

    // Spawn rate
    private float _startTime = 1f;
    private float _repeatRate = 0.5f;

    /// <summary>
    /// Spawn an obstacle every 2 seconds from the start
    /// </summary>
    private void Start()
    {
        InvokeRepeating("SpawnObstacle", _startTime, _repeatRate);
    }

    /// <summary>
    /// Spawn the obstacle (selected prefab in the inspector) at a random position
    /// </summary>
    private void SpawnObstacle()
    {
        Instantiate(_obstaclePrefab, RandomSpawnPosition(), Quaternion.identity, _parentGameObject);
    }

    /// <summary>
    /// Generate a random spawn position (X-axis) at the top of the screen
    /// </summary>
    /// <returns>A <c>Vector3</c> representing spawn position</returns>
    private Vector3 RandomSpawnPosition()
    {
        float randomPositionX = Random.Range(-_spawnPositionXRange, _spawnPositionXRange);
        return new Vector3(randomPositionX, _spawnPositionY, _spawnPositionZ);
    }
}
