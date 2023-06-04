using UnityEngine;

/// <summary>
/// Represent a flying saucer as player's obstacle (INHERITANCE)
/// </summary>
public class FlyingSaucer : Obstacle
{
    private Vector3 _directionX;
    private float _minPositionY = -6f;

    private void Start()
    {
        MoveSpeed *= 3f;
        _directionX = (Random.Range(0, 2) == 1) ? Vector3.right : Vector3.left;
    }

    /// <summary>
    /// Move flying saucer at every frame and destroy it if it's off the screen
    /// </summary>
    private void Update()
    {
        Move();
        DestroyIfOutOfScreen();
    }

    /// <summary>
    /// Move the flying saucer to the bottom of the screen with a slight angle to the left or right (POLYMORPHISM)
    /// </summary>
    public override void Move()
    {
        transform.Translate((Vector3.down + (_directionX / 5f)) * Time.deltaTime * MoveSpeed);
    }

    /// <summary>
    /// Destroys the asteroid if its position exceeds the bottom of the screen
    /// </summary>
    private void DestroyIfOutOfScreen()
    {
        if (transform.position.y < _minPositionY)
        {
            Destroy(gameObject);
        }
    }
}
