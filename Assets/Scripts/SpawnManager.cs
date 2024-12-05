using System;
using UnityEngine;

/// <summary>
/// Class <c>SpawnManager</c> handles the spawn of objects on screen
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private Transform _parentGameObject;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameObject _spaceShipPrefab;

    [Header("Background Stars")]
    [SerializeField] private Transform _parentStars;
    [SerializeField] private GameObject _starPrefab;

    // Spawn position
    private float _spawnPositionXRange = 8f;
    private float _spawnPositionY = 6f;
    private float _spawnPositionZ = 0f;

    // Spawn rates
    private float _startTimeNow = 0f;
    private float _startTimeObstacle = 4f;
    private float _startTimeSpaceShip = 30f;
    private float _repeatRateStar = 0.5f;
    private float _repeatRateObstacle = 0.4f;
    private float _repeatRateObstacleBase = 0.4f;
    private float _repeatRateSpaceShip = 20f;
    private float _repeatRateObstacleStep = 0.1f;

    private int _lastMinute;

    /// <summary>
    /// Spawn an obstacle every 2 seconds from the start
    /// </summary>
    private void Start()
    {
        InvokeRepeating("SpawnStar", _startTimeNow, _repeatRateStar);
        InvokeRepeating("SpawnObstacle", _startTimeObstacle, _repeatRateObstacle);
        InvokeRepeating("SpawnSpaceShip", _startTimeSpaceShip, _repeatRateSpaceShip);
    }

    private void Update()
    {
        IncreaseObstacleRepeatRateEveryMin();
    }

    /// <summary>
    /// Increase obstacle invoke repeat rate every minute.
    /// </summary>
    private void IncreaseObstacleRepeatRateEveryMin()
    {
        // Check current time
        int currentMinute = TimeSpan.FromSeconds(Time.time).Minutes;

        // Minute increase
        if(currentMinute > _lastMinute)
        {
            // Cancel current SpawnObstacle routine
            CancelInvoke("SpawnObstacle");

            // increase repeat rate
            Debug.Log("_repeatRateObstacle:" + _repeatRateObstacle);

            if(!Mathf.Approximately(_repeatRateObstacle,_repeatRateObstacleStep)) {
              _repeatRateObstacle -= _repeatRateObstacleStep;
              Debug.Log("_repeatRateObstacle:"+_repeatRateObstacle);
            }
            
            // Invoke routine again with new repeat rate
            InvokeRepeating("SpawnObstacle", _startTimeNow, _repeatRateObstacle);

            // Store current minute
            _lastMinute = currentMinute;
        }
    }

    /// <summary>
    /// Spawn the obstacle (selected prefab in the inspector) at a random position
    /// </summary>
    private void SpawnObstacle()
    {
        Instantiate(_obstaclePrefab, RandomSpawnPosition(), Quaternion.identity, _parentGameObject);
    }

    /// <summary>
    /// Spawn the obstacle (selected prefab in the inspector) at a random position
    /// </summary>
    private void SpawnSpaceShip()
    {
        Instantiate(_spaceShipPrefab, RandomSpawnPosition(), Quaternion.identity, _parentGameObject);
    }

    /// <summary>
    /// Spawn the obstacle (selected prefab in the inspector) at a random position
    /// </summary>
    private void SpawnStar()
    {
        Instantiate(_starPrefab, RandomSpawnPosition(), Quaternion.identity, _parentStars);
    }

    /// <summary>
    /// Generate a random spawn position (X-axis) at the top of the screen
    /// </summary>
    /// <returns>A <c>Vector3</c> representing spawn position</returns>
    private Vector3 RandomSpawnPosition()
    {
        float randomPositionX = UnityEngine.Random.Range(-_spawnPositionXRange, _spawnPositionXRange);
        return new Vector3(randomPositionX, _spawnPositionY, _spawnPositionZ);
    }

    public void resetRepeatRateObstacle()
    {
        _repeatRateObstacle = _repeatRateObstacleBase;
    }
}
