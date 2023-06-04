using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    private float _moveSpeed = 3.5f;
    private float _moveLimitX = 8.5f;
    private float _moveLimitY = 4.5f;

    private void Update()
    {
        // ABSTRACTION
        Move();
    }

    /// <summary>
    /// Handle player movement based on input axis.
    /// </summary>
    private void Move()
    {
        float moveDirectionX = 0f, moveDirectionY = 0f;

        moveDirectionX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        moveDirectionY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Translate(moveDirectionX, moveDirectionY, transform.position.z);

        // ABSTRACTION
        RepositionIfOutOfGameSpace();
    }

    /// <summary>
    /// Reposition the player to the edges if movement is out of the game space.
    /// </summary>
    private void RepositionIfOutOfGameSpace()
    {
        // Apply X-axis movement constraint
        if (transform.position.x >= _moveLimitX)
            transform.position = new Vector3(_moveLimitX, transform.position.y, transform.position.z);
        if (transform.position.x <= -_moveLimitX)
            transform.position = new Vector3(-_moveLimitX, transform.position.y, transform.position.z);

        // Apply Y-axis movement constraint
        if (transform.position.y >= _moveLimitY)
            transform.position = new Vector3(transform.position.x, _moveLimitY, transform.position.z);
        if (transform.position.y <= -_moveLimitY)
            transform.position = new Vector3(transform.position.x, -_moveLimitY, transform.position.z);
    }

    /// <summary>
    /// ENCAPSULATION
    /// </summary>
    private float MoveSpeed
    {
        set { _moveSpeed = value; }
        get { return _moveSpeed; }
    }
}
