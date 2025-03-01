using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // Singleton pattern

    [Header("Audio Sources")]
    public AudioSource bgmSource;   // For background music
    public AudioSource sfxSource;   // For sound effects

    [Header("Audio Clips")]
    public AudioClip backgroundMusic; // Assign this in the Inspector

    [Header("Sound Effects")]
    public SoundEffect[] soundEffects; // Array to hold all sound effects

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM(backgroundMusic);  // Play the assigned background music
    }

    // Function to play background music
    public void PlayBGM(AudioClip music)
    {
        if (bgmSource.clip == music) return;
        bgmSource.clip = music;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // Function to stop the background music
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // Function to play sound effects by name
    public void PlaySFX(string soundName)
    {
        AudioClip clip = FindSoundEffect(soundName);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);  // Play the clip once
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + soundName);
        }
    }

    // Function to play a specific sound effect directly from the array
    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            sfxSource.PlayOneShot(soundEffects[index].clip);
        }
        else
        {
            Debug.LogWarning("Invalid sound effect index.");
        }
    }

    // Function to find a sound effect by name
    private AudioClip FindSoundEffect(string soundName)
    {
        foreach (SoundEffect effect in soundEffects)
        {
            if (effect.soundName == soundName)
            {
                return effect.clip;
            }
        }
        return null;
    }
}

[System.Serializable]
public class SoundEffect
{
    public string soundName;  // Name of the sound effect (for reference)
    public AudioClip clip;    // The actual audio clip
}
