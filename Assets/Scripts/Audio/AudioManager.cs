using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source---------")]
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
    public AudioClip Earth;
    public AudioClip HitPlayer;
    public AudioClip Death;
    public AudioClip EarthPower;
    public AudioClip UntilVoice;
    public AudioClip Water;
    public AudioClip KetHop;
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

    //public void playSFX2(AudioClip sfxClip, AudioClip sfxClip2)
    //{
    //    SFX.clip = sfxClip;
    //    SFX.PlayOneShot(sfxClip);
    //    int ramdom = Random.Range(1, 10);
    //    if(ramdom >= 8)
    //    {
    //        SFX.clip = sfxClip2;
    //        SFX.PlayOneShot(sfxClip2);
    //    }
    //}
}
