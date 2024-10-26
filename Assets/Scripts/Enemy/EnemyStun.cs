using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    Animator aim;
    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stun()
    {
        aim.SetTrigger("Hit");
        aim.SetBool("Run", false);
        aim.SetBool("Stuned", true);
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMove>().enabled = false;
    }
    public void StunEnd()
    {
        aim.SetBool("Stuned", false);
        GetComponent<EnemyMove>().enabled = true;
        GetComponent<EnemyAttack>().enabled = true;
    }
}
