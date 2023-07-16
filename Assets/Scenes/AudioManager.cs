using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource correctAnswerAudioSource;
    public AudioSource wrongAnswerAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayCorrectAnswerAudio()
    {
        correctAnswerAudioSource.Play();
    }

    public void PlayWrongAnswerAudio()
    {
        wrongAnswerAudioSource.Play();
    }
}
