using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of all obstacles
/// </summary>
public class Obstacle : MonoBehaviour
{
    // Movement
    protected float _moveSpeed = 3.5f;

    /// <summary>
    /// POLYMORPHISM
    /// </summary>
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
