using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNPC : MonoBehaviour
{
    [Header("-------- Audio Source -----------")]
    [SerializeField] AudioSource SFXSource;
    [Header("-------- Audio Clip Speak -------------")]
    public AudioClip[] speak;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
