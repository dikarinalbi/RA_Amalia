using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image hurufBesar;
    public Image objeckHuruf;
    public AudioSource Audio;
    public static CharacterManager Instance { get; private set; }

    private void Start()
    {
        hurufBesar.gameObject.SetActive(false);
        objeckHuruf.gameObject.SetActive(false);
    }

    public void getData(CharacterData chara)
    {
        hurufBesar.gameObject.SetActive(true);
        objeckHuruf.gameObject.SetActive(true);
        hurufBesar.sprite = chara.hurufBesar;
        objeckHuruf.sprite = chara.charObject;
        Audio.clip = chara.voiceover;
        Audio.Play();
    }
}
