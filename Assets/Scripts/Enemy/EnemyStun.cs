using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    Animator aim;

    public bool isStun;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stun()
    {
        aim.SetBool("Stun", true);
        aim.SetTrigger("Hit");
        aim.SetBool("Run", false);
        audioManager.playSFX(audioManager.ParryEnemy);
        
    }
    public void StunEnd()
    {
        aim.SetBool("Stun", false);
        
    }
}
