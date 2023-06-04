using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 3.5f;

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
        float playerMoveX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        float playerMoveY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Translate(playerMoveX, playerMoveY, transform.position.z);
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
