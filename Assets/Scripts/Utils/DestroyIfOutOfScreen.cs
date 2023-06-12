using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfOutOfScreen : MonoBehaviour
{
    private float _minPositionY = -18f;

    void Update()
    {
        DestroyOutOfScreenObject();
    }

    /// <summary>
    /// Destroys objects if its position exceeds the bottom of the screen
    /// </summary>
    private void DestroyOutOfScreenObject()
    {
        if (transform.position.y < _minPositionY)
        {
            Destroy(gameObject);
        }
    }
}
