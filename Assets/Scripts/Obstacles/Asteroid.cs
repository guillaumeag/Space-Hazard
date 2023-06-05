using UnityEngine;

/// <summary>
/// Represent an asteroid as player's obstacle (INHERITANCE)
/// </summary>
public class Asteroid : Obstacle
{
    // Movement
    private float _minMoveSpeed = 4f;
    private float _maxMoveSpeed = 8f;
    private float _minPositionY = -6f;

    // Size
    private float _minSize = 1.5f;
    private float _maxSize = 3f;

    /// <summary>
    /// Generate a random asteroid at start
    /// </summary>
    private void Start()
    {
        // ABSTRACTION
        SetRandomSizeAndSpeed();
    }

    /// <summary>
    /// Move asteroid at every frame and destroy it if it's off the screen
    /// </summary>
    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Move asteroid in direction of the bottom of the screen (POLYMORPHISM)
    /// </summary>
    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
    }

    /// <summary>
    /// Apply random size and movement speed to the asteroid
    /// </summary>
    private void SetRandomSizeAndSpeed()
    {
        // Set random size (ABSTRACTION)
        SetLocalScale(RandomScale(_minSize, _maxSize));

        // Set random movement speed
        MoveSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
    }

    /// <summary>
    /// Set the local scale property to change the size of the asteroid
    /// </summary>
    /// <param name="scale"></param>
    private void SetLocalScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    /// <summary>
    /// Returns a random scale (<c>Vector3</c>) within [minScale..MaxScale] (range is inclusive).
    /// </summary>
    /// <param name="minScale"></param>
    /// <param name="maxScale"></param>
    /// <returns>A <c>Vector3</c> representing new the scale</returns>    
    private Vector3 RandomScale(float minScale, float maxScale)
    {
        float randomScaleValue = Random.Range(minScale, maxScale);
        return new Vector3(randomScaleValue, randomScaleValue, randomScaleValue);
    }
}