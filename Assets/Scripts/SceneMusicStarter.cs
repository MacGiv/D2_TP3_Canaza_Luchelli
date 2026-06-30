using UnityEngine;

/// <summary>
/// Placed in any scene to automatically request the AudioManager to play a specific background track.
/// </summary>
public class SceneMusicStarter : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("La canción que debería sonar en esta escena.")]
    [SerializeField] private AudioClip sceneBGM;

    private void Start()
    {
        if (sceneBGM != null)
        {
            ServiceLocator.GetService<AudioManager>().PlayBGM(sceneBGM);
        }
    }
}