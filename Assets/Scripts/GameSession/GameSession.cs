using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Slider liveSlider;
    public Slider expSlider;
    public Slider staminaSlider;

    public GameObject UI;
    public GameObject Board;

    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI atkUI;
    public TMPro.TextMeshProUGUI defUI;
    public TMPro.TextMeshProUGUI hpUI;
    public TMPro.TextMeshProUGUI hpHealUI;

    public float timeReturnStamina;
    float _timeReturnStamina;
    public int healHP;
    public int healHPNumber;
    // Start is called before the first frame update
    void Start()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        StaminaReturn();
        Heal();
    }
    public void PlayerDeath()
    {
        FindObjectOfType<PlayerTakeDamge>().Death();
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
        StopGame();
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
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
            playerlives += healHP;
            liveSlider.value = playerlives;
        }
        if(playerlives >= playerlivesMax)
        {
            playerlives = playerlivesMax;
        }
    }
}
