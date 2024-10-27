using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource currentaudiosource;
    public float fadeduration = 1f;
    [Header("-------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip -------------")]
    public AudioClip Background;
    public AudioClip bossmusic1;
    public AudioClip bossmusic2;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void ChangeMusic(AudioClip newmusic)
    {
        StartCoroutine(FadeOutAndChangeMusic(newmusic));
    }
    private IEnumerator FadeOutAndChangeMusic(AudioClip newmusic)
    {
        float startVolume = currentaudiosource.volume;
        //fade out
        for (float t = 0; t < fadeduration; t += Time.deltaTime)
        {
            currentaudiosource.volume = Mathf.Lerp(startVolume, 0, t / fadeduration);
            yield return null;
        }
        currentaudiosource.volume = 0;
        currentaudiosource.Stop();
        currentaudiosource.clip = newmusic;
        currentaudiosource.Play();
        //fade in
        for (float t = 0; t < fadeduration; t += Time.deltaTime)
        {
            currentaudiosource.volume = Mathf.Lerp(0, startVolume, t / fadeduration);
            yield return null;
        }

        currentaudiosource.volume = startVolume;
    }

    internal void PlaySFX(object bossSound)
    {
        throw new NotImplementedException();
    }
}
