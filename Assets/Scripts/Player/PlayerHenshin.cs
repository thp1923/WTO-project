using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHenshin : MonoBehaviour
{
    public GameObject Flast;
    public int staminaCost;
    public GameObject Earth;

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
        if (Input.GetKeyDown(KeyCode.T) && _timeCD <= 0 && stamina >= staminaCost)
        {
            aim.SetTrigger("Henshin");
            aim.SetBool("EndUntil", false);
            _timeCD = timeCD;
            Flast.SetActive(true);
            Time.timeScale = 0;
            audioManager.playSFX(audioManager.EarthPower);
            GetComponent<PlayerMove>().Stop();
            FindObjectOfType<GameSession>().CostStamina(staminaCost);

        }
        else
        {
            _timeCD -= Time.deltaTime;
        }
    }
    public void haveParry()
    {
        FindObjectOfType<PlayerTakeDamge>().haveParry = true;
    }
    public void noParry()
    {
        FindObjectOfType<PlayerTakeDamge>().haveParry = false;
    }
    public void earthTrue()
    {
        Earth.SetActive(true);
    }
}
