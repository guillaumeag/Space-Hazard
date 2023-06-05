using UnityEngine;
using TMPro;

public class Star : MonoBehaviour
{
    private TextMeshPro _textComponent;

    private float _fontSizeMin = 1f;
    private float _fontSizeMax = 6f;

    void Start()
    {
        _textComponent = GetComponent<TextMeshPro>();

        _textComponent.fontSize = Random.Range(_fontSizeMin, _fontSizeMax);
        _textComponent.fontStyle = (Random.Range(0, 2) == 1) ? FontStyles.Bold : FontStyles.Normal;
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Move the star in direction of the bottom of the screen
    /// </summary>
    private void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
