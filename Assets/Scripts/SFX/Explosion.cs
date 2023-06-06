using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Explosion class represents an ASCII visual explosion effect
/// </summary>
public class Explosion : AsciiEffect, IEffect
{
    private void Start()
    {
        IEnumerator coroutine = WaitBeforeDestroy(2f);
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        ExecuteEffect();
    }

    /// <summary>
    /// Increment character and line spacing during the effect to simulate explosion
    /// </summary>
    public void ExecuteEffect()
    {
        TextMeshProComponent.characterSpacing += 8f;
        TextMeshProComponent.lineSpacing += 8f;
    }

    /// <summary>
    /// Run exposion effect for <c>duration</c> seconds
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public IEnumerator WaitBeforeDestroy(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
