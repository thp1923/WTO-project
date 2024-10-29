using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKetHop : MonoBehaviour
{
    public GameObject Flast;
    public int staminaCost;
    public GameObject KetHop1;

    public GameObject SkillUI;
    public GameObject round;
    public TMPro.TextMeshProUGUI textCD;

    public float timeCD;
    float _timeCD;
    Animator aim;
    int stamina;

    bool haveSkill;

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
        haveSkill = FindObjectOfType<GameSession>().haveKetHop;
        if (!haveSkill) SkillUI.SetActive(false);
        else SkillUI.SetActive(true);
        textCD.text = _timeCD.ToString("F1");
        if (_timeCD <= 0) round.SetActive(false);
        else round.SetActive(true);
        Attack();
    }
    void Attack()
    {
        if (haveSkill == false) return;
        if (Input.GetKeyDown(KeyCode.P) && _timeCD <= 0 && stamina >= staminaCost)
        {
            aim.SetTrigger("KetHop");
            aim.SetBool("EndUntil", false);
            _timeCD = timeCD;
            Flast.SetActive(true);
            Time.timeScale = 0;
            audioManager.playSFX(audioManager.KetHop);
            GetComponent<PlayerMove>().Stop();
            FindObjectOfType<GameSession>().CostStamina(staminaCost);

        }
        else
        {
            _timeCD -= Time.deltaTime;
        }
    }
    public void kethopTrue()
    {
        KetHop1.SetActive(true);
    }
}
