using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource stepsSource;

    private void Awake()
    {
        stepsSource = GetComponent<AudioSource>();
    }

    private void EstherStep()
    {
        stepsSource.Play();
    }
}
