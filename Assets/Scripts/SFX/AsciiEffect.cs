using UnityEngine;
using TMPro;

/// <summary>
/// Abstract class <c>AsciiEffect</c> represents the basis of an ASCII Visual Effect (ABSTRACTION)
/// </summary>
public abstract class AsciiEffect : MonoBehaviour
{
    /// <summary>
    /// Property to get TMP component from child (ENCAPSULATION)
    /// </summary>
    protected TextMeshPro TextMeshProComponent { get; set; }

    private void Awake()
    {
        // Set the property at start
        TextMeshProComponent = GetComponent<TextMeshPro>();
    }    
}
