using System.Collections;

/// <summary>
/// Interface that force implementing methods for ASCII Visual Effect (ABSTRACTION)
/// </summary>
public interface IEffect
{
    IEnumerator WaitBeforeDestroy(float duration);
    void ExecuteEffect();
}
