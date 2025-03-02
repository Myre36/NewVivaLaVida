using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // Singleton pattern

    [Header("Audio Sources")]
    public AudioSource bgmSource;   // For background music
    public AudioSource sfxSource;   // For sound effects

    [Header("Audio Clips")]
    public AudioClip backgroundMusic; // Assign this in the Inspector

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

}

[System.Serializable]
public class SoundEffect
{
    public string soundName;  // Name of the sound effect (for reference)
    public AudioClip clip;    // The actual audio clip
}
