using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlivesMax = 1000;
    public int playerlives;

    public Slider liveSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerlives = playerlivesMax;
        liveSlider.maxValue = playerlivesMax;
        liveSlider.value = playerlivesMax;
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

}
