using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    Animator aim;
    Rigidbody2D rig;
    Transform target;

    public int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask playerLayer;

    public float AttackDamge1;

    public float knockBack = 5f;
    public float knockBackUp = 1f;


    float Damge;
    bool isFlip;
    // Start is called before the first frame update
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
        Attack1();
    }
    public void Attack1()
    {
        Damge = BaseAttack * AttackDamge1;
        Attack();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, playerLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            FindObjectOfType<PlayerTakeDamge>().FlipTakeDamge(isFlip);
            enemy.GetComponent<PlayerTakeDamge>().TakeDamge(BaseAttack, Damge, knockBack, knockBackUp);
            Destroy(gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);

    }
}
