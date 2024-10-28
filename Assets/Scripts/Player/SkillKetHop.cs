using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKetHop : MonoBehaviour
{
    public GameObject active;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextSkill()
    {
        active.SetActive(true);
    }
    public void endCurrentSkill()
    {
        gameObject.SetActive(false);
    }
    
}
