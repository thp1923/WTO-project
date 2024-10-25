using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlivesMax = 1000;
    public int playerlives;

    public int BaseDamge;
    public int Def;

    public int Level;
    public int exp;
    public int expMax;

    public Slider liveSlider;
    public Slider expSlider;

    public GameObject UI;
    public GameObject Board;

    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI atkUI;
    public TMPro.TextMeshProUGUI defUI;
    public TMPro.TextMeshProUGUI hpUI;
    // Start is called before the first frame update
    void Start()
    {
        playerlives = playerlivesMax;
        liveSlider.maxValue = playerlivesMax;
        liveSlider.value = playerlivesMax;
        expSlider.maxValue = expMax;
        level.text = Level.ToString();
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
}
