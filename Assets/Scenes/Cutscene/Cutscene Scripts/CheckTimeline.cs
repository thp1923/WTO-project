using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class CheckTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector.played += OnPlayableDirectorPlayed;
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered zone");
            playableDirector.Play();
        }
    }
    void OnPlayableDirectorPlayed(PlayableDirector playableDirector)
    {
    }
    void OnPlayableDirectorStopped(PlayableDirector playableDirector)
    {
    }
}
