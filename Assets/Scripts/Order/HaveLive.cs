using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveLive : MonoBehaviour
{
    bool haveSkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        haveSkill = FindObjectOfType<GameSession>().haveHenshin;
        if (haveSkill) 
            Destroy(gameObject);
    }
}
