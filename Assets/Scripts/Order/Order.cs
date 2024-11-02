using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void False()
    {
        gameObject.SetActive(false);
    }
    public void TimeScale()
    {
        Time.timeScale = 1;
    }
    public void playAgain()
    {
        FindObjectOfType<GameSession>().PlayAgain();
    }
    public void audioFlast()
    {
        audioManager.playSFX(audioManager.Flast);
    }
}
