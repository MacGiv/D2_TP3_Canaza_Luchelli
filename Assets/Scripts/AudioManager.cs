using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Handles all audio playback in the game. Registered in the ServiceLocator.
/// </summary>
public class AudioManager : MonoBehaviour, IService
{
    private AudioSource bgmSource;

    private void Awake()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.playOnAwake = false;
        bgmSource.volume = 1f;
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

    public void Initialize(GameSettingsSo settingsSo)
    {
        if (settingsSo.BGMMixerGroup != null)
        {
            bgmSource.outputAudioMixerGroup = settingsSo.BGMMixerGroup;
        }
        else
        {
            Debug.LogWarning("AudioManager: BGMMixerGroup not assigned.");
        }
    }

    public void DeInitialize()
    {
        Destroy(gameObject);
    }
}