using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Animator aim;
    Rigidbody2D rig;
    public Transform target;

    public int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask playerLayer;

    public float attackRange;
    void Start()
    {
        aim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerTakeDamge>().isDeath == true)
        {
            return;
        }
        
        Debug.DrawRay(rig.position, Vector2.right * attackRange, Color.red);
        Debug.DrawRay(rig.position, Vector2.left * attackRange, Color.red);
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            aim.SetTrigger("Attack1");
            aim.SetBool("Run", false);
            //GetComponent<EnemyMove>().enabled = false;
        }
        else 
        {
            //GetComponent<EnemyMove>().enabled = true;
            return;
        }
    }
    public void Attack1()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, playerLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerTakeDamge>().TakeDamge(BaseAttack);


        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);

    }
}
