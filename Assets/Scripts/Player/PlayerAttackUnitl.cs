using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackUnitl : MonoBehaviour
{
    public GameObject Until;

    public float timeCD;
    float _timeCD;
    Animator aim;
    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && _timeCD <= 0)
        {
            aim.SetTrigger("Until");
            aim.SetBool("EndUntil", false);
            _timeCD = timeCD;
            
        }
        else
        {
            _timeCD -= Time.deltaTime;
        }
    }
    public void UntilSkill()
    {
        Until.SetActive(true);
        GetComponent<PlayerMove>().enabled = false;
    }
    public void EndUntil()
    {
        GetComponent<PlayerMove>().enabled = true;
        aim.SetBool("EndUntil", true);
    }
}
