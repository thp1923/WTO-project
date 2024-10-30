using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveNgoc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ngoc()
    {
        FindObjectOfType<GameSession>().haveMangNgoc2 = true;
        Time.timeScale = 1;
    }
}
