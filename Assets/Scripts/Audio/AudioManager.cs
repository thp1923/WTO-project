using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source---------")]
    public AudioSource SFX;
    [SerializeField] AudioSource SFXSource;
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
    public AudioClip ElevatorOpen;
    public AudioClip Death;
    public AudioClip EarthPower;
    public AudioClip UntilVoice;
    public AudioClip Water;
    public AudioClip KetHop;
    [Header("-------- Audio Clip Speak -------------")]
    public AudioClip[] speak;
    private int index;
    // Start is called before the first frame update
    private void Awake()
    {
        //so luong doi tuong GameSession
        int numbersession = FindObjectsOfType<AudioManager>().Length;
        //neu no co nhieu hon phien ban thi se huy no
        if (numbersession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject); //khong cho huy khi load
    }
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

    public void PlaySFXNPC(AudioClip[] clip)
    {
        if (index >= 0 && index < clip.Length)
        {
            SFXSource.PlayOneShot(clip[index]);
            index++;
            Debug.Log("Có chạy " + index);
        }
    }
}
