using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSkill : MonoBehaviour
{
    public int skillNumber;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameSession>().learnSkill(skillNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
