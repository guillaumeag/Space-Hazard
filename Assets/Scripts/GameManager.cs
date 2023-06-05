using UnityEngine;

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
        if (_isGameActive && _player == null)
        {
            _audioSource.PlayOneShot(_gameOverAudioClip);
            _isGameActive = false;
        }
    }
}
