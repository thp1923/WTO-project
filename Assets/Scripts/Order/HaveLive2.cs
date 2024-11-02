using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveLive2 : MonoBehaviour
{
    bool haveSkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        haveSkill = FindObjectOfType<GameSession>().haveMangNgoc2;
        if (haveSkill)
            Destroy(gameObject);
    }
}
