using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveLive : MonoBehaviour
{
    bool haveSkill;
    // Start is called before the first frame update
    void Start()
    {
        haveSkill = FindObjectOfType<GameSession>().haveHenshin;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveSkill) 
            Destroy(gameObject);
    }
}
