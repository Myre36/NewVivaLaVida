using UnityEngine;

public class SoundChecker : MonoBehaviour
{
    private GameManager gameManager;

    private AudioSource sound;

    [SerializeField]
    private bool librarySound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sound = GetComponent<AudioSource>();
        if(gameManager.heardLibrarySound)
        {
            Destroy(gameObject);
        }
        else
        {
            sound.Play();
            gameManager.heardLibrarySound = true;
        }
    }
}
