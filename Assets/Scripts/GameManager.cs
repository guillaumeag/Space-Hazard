using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Attached objects & components
    [Header("Game Objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private SpawnManager _spawnManager;

    [Header("Sounds")]
    [SerializeField] private AudioClip _gameOverAudioClip;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _uiElapsedTime;

    // Members
    private bool _isGameActive;

    // Components
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _isGameActive = true;
    }

    private void Update()
    {
        UpdateElapsedTime();
        GameOver();
        Restart();
    }

    /// <summary>
    /// Play a sound if player is destroyed during active game and set game unactive
    /// </summary>
    private void GameOver()
    {
        if (_isGameActive && _player == null)
        {
            _audioSource.PlayOneShot(_gameOverAudioClip);
            _isGameActive = false;
        }
    }

    /// <summary>
    /// Reload the game scene to restart
    /// </summary>
    private void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // Reset time
            // TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
            // _uiElapsedTime.text = "00:00:00";

            // Reset obstacle repeat rate
            _spawnManager.resetRepeatRateObstacle();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    /// <summary>
    /// Show current elapsed time on screen
    /// </summary>
    private void UpdateElapsedTime()
    {
        if (_isGameActive)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
            _uiElapsedTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
