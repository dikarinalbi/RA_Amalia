using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngkaManager : MonoBehaviour
{
    public Image angkaPapantulis;
    public AudioSource Audio;
    public static AngkaManager Instance { get; private set; }

    private void Start()
    {
        angkaPapantulis.gameObject.SetActive(false);
    }
    public void getData(CharacterData chara)
    {
        angkaPapantulis.gameObject.SetActive(true);
        angkaPapantulis.sprite = chara.Angka;
        Audio.clip = chara.voiceover;
        Audio.Play();
    }
}
