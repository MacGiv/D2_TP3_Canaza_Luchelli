using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Handles all audio playback in the game. Registered in the ServiceLocator.
/// </summary>
public class AudioManager : MonoBehaviour, IService
{
    private AudioSource bgmSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    /// <summary>
    /// Initializes the service with the provided game settings.
    /// </summary>
    public void Initialize(GameSettingsSo settingsSo) 
    {
        musicSource.volume = AudioData.MasterVolume;
        sfxSource.volume = AudioData.SfxVolume;

        EventBus.Subscribe<SfxRequestedEvent>(OnSFXRequested);
    }

    private void Awake()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.playOnAwake = false;
        bgmSource.volume = 1f;
    }

    /// <summary>
    /// Deinitializes the service and destroys the attached GameObject.
    /// </summary>
    public void DeInitialize()
    {
        EventBus.Unsubscribe<SfxRequestedEvent>(OnSFXRequested);

        Destroy(gameObject);
    }

    public void PlayBGM(AudioClip newClip)
    {
        if (newClip == null) return;
        if (bgmSource.clip == newClip && bgmSource.isPlaying) return;

        bgmSource.Stop();
        bgmSource.clip = newClip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    private void OnSFXRequested(SfxRequestedEvent sfxRequestedEvent) 
        => sfxSource.PlayOneShot(sfxRequestedEvent.clip);
}