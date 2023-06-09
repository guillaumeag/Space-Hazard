using UnityEngine;

public class Reactor : MonoBehaviour
{
    // Power levels
    private readonly Vector3 _powerMedium = Vector3.one;
    private readonly Vector3 _powerLow = new Vector3(0.8f, 0.8f, 0.8f);
    private readonly Vector3 _powerHigh = new Vector3(1.2f, 1.2f, 1.2f);

    private void Update()
    {
        // Update reactor power based on Y-Axis input
        ReactorPowerControl(Input.GetAxis("Vertical"));
    }

    /// <summary>
    /// Increase or decrease the scale of the game object according <c>power</c> parameter
    /// </summary>
    /// <param name="power">A <c>float</c> that varies between 1f and -1f. More than 0 = High, 0 = Medium, Less than 0 = Low.</param>
    private void ReactorPowerControl(float power)
    {
        switch (power)
        {
            case < 0f:
                transform.localScale = _powerLow;
                break;
            case > 0f:
                transform.localScale = _powerHigh;
                break;
            default:
                transform.localScale = _powerMedium;
                break;
        }
    }
}
