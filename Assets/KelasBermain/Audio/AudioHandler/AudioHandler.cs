using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip1);
    }

    public void playAudio(AudioClip Audio)
    {
        audioSource.PlayOneShot(Audio);
    }

    public void playBGM()
    {
        audioSource.clip = clip2;
        audioSource.Play();
    }

    public void playBacktoOriginalBGM()
    {
        audioSource.clip = clip3;
        audioSource.Play();
    }


}
