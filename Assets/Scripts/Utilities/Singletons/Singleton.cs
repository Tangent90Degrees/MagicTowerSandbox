using UnityEngine;

/// <summary>
/// Singleton is the base class from which every managers derives.
/// </summary>
/// <typeparam name="T">The type of this singleton.</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    /// <summary>
    /// The only instance of this singleton.
    /// </summary>
    protected static T Instance { get; private set; }


    /// <summary>
    /// Set the instance to this if has not initialized.
    /// Destroy this if has initialized.
    /// </summary>
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }


    /// <summary>
    /// Set the instance to null.
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    
}
