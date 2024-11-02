using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlivesMax;
    public int playerlives;
    public int staminaMax;
    public int stamina;

    public int BaseDamge;
    public int Def;

    public int Level;
    public int exp;
    public int expMax;
    public int canHealNumber;

    public Slider liveSlider;
    public Slider expSlider;
    public Slider staminaSlider;

    public GameObject UI;
    public GameObject Board;
    public bool haveUI;
    public GameObject gameOver;
    public GameObject Begin;

    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;

    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI atkUI;
    public TMPro.TextMeshProUGUI defUI;
    public TMPro.TextMeshProUGUI hpUI;
    public TMPro.TextMeshProUGUI hpHealUI;

    public float timeReturnStamina;
    float _timeReturnStamina;
    int healHP;
    public int healHPNumber;
    [Header("----------Skill----------")]
    public bool haveUnitl;
    public bool haveHenshin;
    public bool haveKetHop;

    public bool canKetHop;
    public bool haveMangNgoc2;
    public GameObject canKetHopSkill;
    public GameObject mangNgoc1;
    public GameObject mangNgoc2;


    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        haveUI = true;
        playerlives = playerlivesMax;
        stamina = staminaMax;

        liveSlider.maxValue = playerlivesMax;
        liveSlider.value = playerlivesMax;
        expSlider.maxValue = expMax;
        staminaSlider.maxValue = staminaMax;
        staminaSlider.value = stamina;
        level.text = Level.ToString();
        hpHealUI.text = healHPNumber.ToString();
    }
    private void Awake()
    {
        //so luong doi tuong GameSession
        int numbersession = FindObjectsOfType<GameSession>().Length;
        //neu no co nhieu hon phien ban thi se huy no
        if (numbersession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject); //khong cho huy khi load
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        StaminaReturn();
        Heal();
        showSkill();
    }
    public void showSkill()
    {
        if (haveUnitl)
            Skill1.SetActive(true);
        else
            Skill1.SetActive(false);
        if (haveHenshin)
        {
            mangNgoc1.SetActive(true);
            Skill2.SetActive(true);
        }
        else
        {
            mangNgoc1.SetActive(false);
            Skill2.SetActive(false);
        }
        if (haveKetHop)
        {
            canKetHopSkill.SetActive(false);
            Skill3.SetActive(true);
        }
        else
        {
            Skill3.SetActive(false);
        }
        if (haveMangNgoc2)
            mangNgoc2.SetActive(true);
        else
            mangNgoc2.SetActive(false);
        if (haveHenshin && haveMangNgoc2)
            canKetHop = true;
        if (canKetHop)
            canKetHopSkill.SetActive(true);
    }
    public void PlayerDeath()
    {
        FindObjectOfType<PlayerTakeDamge>().Death();
        gameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        //lay index cua scene hien tai
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        //load lai scene hien tai

        SceneManager.LoadScene(currentsceneindex);
        Time.timeScale = 1;
        //Destroy(gameObject); //destroy GameSession luon
        Begin.SetActive(true);
        playerlives = playerlivesMax;
        stamina = staminaMax;
        liveSlider.value = playerlives;
        staminaSlider.value = stamina;
    }
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);//load lai Scene 0
        Time.timeScale = 1;

    }
    //doat mang
    public void TakeLife(int damgeEnemy)
    {

        playerlives -= damgeEnemy;//giam mang
        liveSlider.value = playerlives;
        if (playerlives <= 0)
        {
            PlayerDeath();
        }
    }

    public void upExp(int expUp)
    {
        exp += expUp;
        expSlider.value = exp;
        canHealNumber++;
        if (canHealNumber >= 5)
        {
            healHPNumber++;
            canHealNumber -= 5;
            hpHealUI.text = healHPNumber.ToString();
        }
        if(exp >= expMax)
        {
            exp -= expMax;
            upLevel();
        }
    }
    public void upLevel()
    {
        Level += 1;
        expMax = (int)(expMax * 1.3);
        BaseDamge = (int)(BaseDamge * 1.2);
        playerlivesMax = (int)(playerlivesMax * 1.1);
        level.text = Level.ToString();
        expSlider.maxValue = expMax;
        expSlider.value = exp;
    }

    public void Avarta()
    {
        atkUI.text = BaseDamge.ToString();
        defUI.text = Def.ToString();
        hpUI.text = playerlivesMax.ToString();
        haveUI = false;
        StopGame();
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        haveUI = true;
        Time.timeScale = 1;
    }
    public void CostStamina(int cost)
    {
        stamina -= cost;
        staminaSlider.value = stamina;
    }
    public void StaminaReturn()
    {
        _timeReturnStamina -= Time.deltaTime;
        if(stamina < staminaMax && _timeReturnStamina <= 0)
        {
            stamina += 2;
            _timeReturnStamina = timeReturnStamina;
            staminaSlider.value = stamina;
        }
    }
    public void Heal()
    {
        if(Input.GetKeyDown(KeyCode.I) && healHPNumber > 0 && playerlives < playerlivesMax)
        {
            healHPNumber--;
            healHP = (int)(playerlivesMax/3);
            hpHealUI.text = healHPNumber.ToString();
            audioManager.playSFX(audioManager.Heal);
            playerlives += healHP;
            liveSlider.value = playerlives;
        }
        if(playerlives >= playerlivesMax)
        {
            playerlives = playerlivesMax;
        }
    }
    public void learnSkill(int skillNumber)
    {
        if (skillNumber == 1)
            haveUnitl = true;
        if (skillNumber == 2)
            haveHenshin = true;
        if (skillNumber == 3)
            haveKetHop = true;
    }
    public void True()
    {
        UI.SetActive(true);
    }
    public void False()
    {
        UI.SetActive(false);
    }
}
