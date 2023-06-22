using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The manager of scene transitions
/// </summary>
public class TransitionManager : Singleton<TransitionManager>
{

    /// <summary>
    /// If exists transiting scenes.
    /// </summary>
    public static bool IsTransiting
    {
        get => _isTransiting;
        private set => _isTransiting = value;
    }


    /// <summary>
    /// Transits from current scene to a new scene.
    /// </summary>
    /// <param name="from">the current scene to unload.</param>
    /// <param name="to">the new scene to load.</param>
    public static void Transit(string from, string to)
    {
        if (!IsTransiting)
        {
            Instance.StartCoroutine(TransitionCoroutine(from, to));
        }
    }


    /// <summary>
    /// Returns the coroutine of scene transition.
    /// </summary>
    /// <param name="from">the current scene to unload.</param>
    /// <param name="to">the new scene to load.</param>
    private static IEnumerator TransitionCoroutine(string from, string to)
    {
        IsTransiting = true;
        yield return FadeEffectCoroutine(1);
        
        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to);

        // Set new scene active.
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return FadeEffectCoroutine(0);
        IsTransiting = false;
    }


    /// <summary>
    /// Returns the coroutine of scene transition fade effect.
    /// </summary>
    /// <param name="targetAlpha">0 is transparent, 1 is black.</param>
    private static IEnumerator FadeEffectCoroutine(float targetAlpha)
    {
        CanvasGroup fadeCanvasGroup = Instance._fadeCanvasGroup;
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / Instance._fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
    }


    #region On Inspector

    [Header("Transition Fading")]
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
    [SerializeField] private float _fadeDuration;

    #endregion


    private static bool _isTransiting;

}
