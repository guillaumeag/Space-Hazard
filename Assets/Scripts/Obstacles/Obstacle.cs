using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Movement
    protected float _moveSpeed = 3.5f;

    public virtual void Move() { }

    /// <summary>
    /// ENCAPSULATION
    /// </summary>
    protected float MoveSpeed
    {
        set { _moveSpeed = value; }
        get { return _moveSpeed; }
    }
}
