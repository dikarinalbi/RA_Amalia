using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashHandler : MonoBehaviour
{
    Animation splashanim;
    public Animator anim;
    public Animator present;
    public GameObject playbackground;
    public GameObject splash;
    public AudioSource audios;
    public AudioClip clip;
    void Start()
    {
       StartCoroutine(splashAnimation());
    }
    /*private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("SplahAnim"))
        {
            // Avoid any reload.
            Debug.Log("has stoped");
        }
    }*/

    private IEnumerator splashAnimation()
    {
        yield return new WaitForSeconds(4);
        splash.SetActive(false);
        playbackground.SetActive(true);
        audios.PlayOneShot(clip);
    }
}
