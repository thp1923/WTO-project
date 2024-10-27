using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("--------Audio Source---------")]
    public AudioSource SFX;
    [Header("--------Audio Clip---------")]
    public AudioClip Run;
    // Start is called before the first frame update
    void Start()
    {
        SFX.clip = Run;
        SFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
