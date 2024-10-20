using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamge : MonoBehaviour
{
    public int maxHp;
    int HP;
    public GameObject Hit;
    Animator animator;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHp;
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int Damge)
    {
        HP -= Damge;
        animator.SetTrigger("Hit");
        Instantiate(Hit, rig.position, transform.rotation);
        if (HP <= 0)
        {
            animator.SetBool("Death", true);
            rig.gravityScale = 0;
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<EnemyAttack>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
