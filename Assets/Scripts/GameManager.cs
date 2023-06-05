using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject _player;

    [Header("Sounds")]
    [SerializeField] private AudioClip _gameOverAudioClip;

    private bool _isGameActive;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _isGameActive = true;
    }

    private void Update()
    {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
