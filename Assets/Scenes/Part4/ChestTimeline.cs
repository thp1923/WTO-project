using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class ChestTimeline : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject canvasInfo;
    // Start is called before the first frame update
    void Start()
    {
        director.played += OnPlayableDirectorPlayed;
        director.stopped += OnPlayableDirectorStopped;
        canvasInfo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            director.Play();
        }
    }

    void OnPlayableDirectorPlayed(PlayableDirector aDirector)
    {
        canvasInfo.SetActive(true);
    }
    
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
    }
}
