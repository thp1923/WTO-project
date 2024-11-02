using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSkill : MonoBehaviour
{
    public int skillNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skill()
    {
        FindObjectOfType<GameSession>().learnSkill(skillNumber);
        FindObjectOfType<GameSession>().Resume();
        Destroy(gameObject);
    }
}
