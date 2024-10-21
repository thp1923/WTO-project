using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int playerlivesMax = 1000;
    public int playerlives;
    // Start is called before the first frame update
    void Start()
    {
        playerlives = playerlivesMax;
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
        
        if (playerlives <= 0)
        {
            PlayerDeath();
        }
    }

}
