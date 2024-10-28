using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Animator aim;
    Rigidbody2D rig;
    public Transform target;

    public int BaseAttack;
    public float AttackRange;
    public Transform AttackPoint;
    public LayerMask playerLayer;
    public Transform attack;

    public float AttackDamge1;
    public float AttackDamge2;

    public float knockBack = 5f;
    public float knockBackUp = 1f;

    public float attackRange;

    public int enegy;
    public int enegyNeed;

    float Damge;
    bool isFlip;
    void Start()
    {
        aim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerTakeDamge>().isDeath == true)
        {
            return;
        }
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isFlip = GetComponent<EnemyMove>().isFlip;
        Debug.DrawRay(rig.position, Vector2.right * attackRange, Color.red);
        Debug.DrawRay(rig.position, Vector2.left * attackRange, Color.red);
        if (Vector2.Distance(attack.position, target.position) < attackRange)
        {
            aim.SetBool("Run", false);
            NormalAttack();
            
            GetComponent<EnemyMove>().enabled = false;
        }
        else
        {
            GetComponent<EnemyMove>().enabled = true;
            return;
        }
    }

    public void NormalAttack()
    {
        if(enegy < enegyNeed)
        {
            aim.SetTrigger("Attack1");
            enegy += Random.Range(1, 4);
        }
        else
        {
            aim.SetTrigger("Attack2");
            enegy -= enegyNeed;
        }
    }
    public void Attack1()
    {
        Damge = BaseAttack * AttackDamge1;
        Attack();
    }
    public void Attack2()
    {
        Damge = BaseAttack * AttackDamge2;
        Attack();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, playerLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            FindObjectOfType<PlayerTakeDamge>().FlipTakeDamge(isFlip);
            enemy.GetComponent<PlayerTakeDamge>().TakeDamge(BaseAttack, Damge, knockBack, knockBackUp);


        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);

    }
}
