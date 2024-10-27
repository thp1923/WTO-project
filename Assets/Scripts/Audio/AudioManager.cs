using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source---------")]
    public AudioSource Music;
    public AudioSource SFX;
    [Header("--------Audio Clip---------")]
    public AudioClip Parry;
    public AudioClip Flast;
    public AudioClip Until;
    public AudioClip Heal;
    public AudioClip Hit;
    public AudioClip Punch;
    public AudioClip ParryEnemy;
    public AudioClip Jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(AudioClip sfxClip)
    {
        SFX.clip = sfxClip;
        SFX.PlayOneShot(sfxClip);
    }
}
