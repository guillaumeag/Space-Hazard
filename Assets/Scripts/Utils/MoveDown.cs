using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Move game object down screen
    /// </summary>
    private void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
