using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// INHERITANCE
/// </summary>
public class Asteroid : Obstacle
{
    // Movement
    private float _moveDirection = -1f;
    private float _minMoveSpeed = 4f;
    private float _maxMoveSpeed = 8f;

    // Size
    private float _minSize = 1.5f;
    private float _maxSize = 3f;

    private void Start()
    {
        // ABSTRACTION
        // Create random asteroid
        SetRandomSize();
        SetRandomMoveSpeed();
    }

    private void Update()
    {
        Move();
    }

    private void SetRandomSize()
    {
        float randomSize = Random.Range(_minSize, _maxSize);

        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

    private void SetRandomMoveSpeed()
    {
        float randomMoveSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
        MoveSpeed = randomMoveSpeed;
    }

    /// <summary>
    /// POLYMORPHISM
    /// </summary>
    public override void Move()
    {
        float moveDirectionY = _moveDirection * Time.deltaTime * MoveSpeed;
        transform.Translate(transform.position.x, moveDirectionY, transform.position.z);
    }
}
