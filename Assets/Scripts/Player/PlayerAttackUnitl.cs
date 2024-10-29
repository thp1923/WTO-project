using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackUnitl : MonoBehaviour
{
    public GameObject Until;
    public GameObject Flast;
    public int staminaCost;

    public GameObject SkillUI;
    public GameObject round;
    public TMPro.TextMeshProUGUI textCD;

    public float timeCD;
    float _timeCD;
    Animator aim;
    int stamina;

    AudioManager audioManager;
    bool haveSkill;

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
        haveSkill = FindObjectOfType<GameSession>().haveUnitl;
        stamina = FindObjectOfType<GameSession>().stamina;
        if (!haveSkill) SkillUI.SetActive(false);
        else SkillUI.SetActive(true);
        textCD.text = _timeCD.ToString("F1");
        if(_timeCD <= 0) round.SetActive(false);
        else round.SetActive(true);
        Attack();
        
    }
    void Attack()
    {
        if (haveSkill == false) return;
        if (Input.GetKeyDown(KeyCode.K) && _timeCD <= 0 && stamina >= staminaCost)
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
        GetComponent<PlayerMove>().Stop();
        GetComponent<PlayerMove>().enabled = false;
    }
    public void EndUntil()
    {
        GetComponent<PlayerMove>().Move();
        GetComponent<PlayerMove>().enabled = true;
        aim.SetBool("EndUntil", true);
    }
}
