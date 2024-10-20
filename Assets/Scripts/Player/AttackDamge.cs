using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamge : MonoBehaviour
{
    public int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask enemyLayer;

    public int DamgeNormal1;
    public int DamgeNormal2;
    public int DamgeNormal3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NormalAttck1()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTakeDamge>().TakeDamge(BaseAttack);


        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);

    }
}
