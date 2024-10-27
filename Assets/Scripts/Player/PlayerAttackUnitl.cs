using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackUnitl : MonoBehaviour
{
    public GameObject Until;
    public GameObject Flast;
    public int staminaCost;

    public float timeCD;
    float _timeCD;
    Animator aim;
    int stamina;

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
        stamina = FindObjectOfType<GameSession>().stamina;
        if(Input.GetKeyDown(KeyCode.L) && _timeCD <= 0 && stamina >= staminaCost)
        {
            aim.SetTrigger("Until");
            aim.SetBool("EndUntil", false);
            _timeCD = timeCD;
            Flast.SetActive(true);
            Time.timeScale = 0;
            audioManager.playSFX(audioManager.UntilVoice);
            FindObjectOfType<GameSession>().CostStamina(staminaCost);
            
        }
        else
        {
            _timeCD -= Time.deltaTime;
        }
    }
    public void UntilSkill()
    {
        Until.SetActive(true);
        GetComponent<PlayerMove>().enabled = false;
    }
    public void EndUntil()
    {
        GetComponent<PlayerMove>().enabled = true;
        aim.SetBool("EndUntil", true);
    }
}
