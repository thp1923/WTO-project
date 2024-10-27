using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamge : MonoBehaviour
{
    int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;

    public Vector2 AttackRange2;
    public Transform AttackPoint2;

    public LayerMask enemyLayer;

    public float DamgeNormal1;
    public float DamgeNormal2;
    public float DamgeNormal3;
    public float DamgeHenshin;

    float Damge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BaseAttack = FindObjectOfType<GameSession>().BaseDamge;
    }
    public void Normal1()
    {
        Damge = BaseAttack * DamgeNormal1;
        Attack();
    }
    public void Normal2()
    {
        Damge = BaseAttack * DamgeNormal2;
        Attack();
    }
    public void Normal3()
    {
        Damge = BaseAttack * DamgeNormal3;
        Attack();
    }
    public void Henshin()
    {
        Damge = BaseAttack * DamgeHenshin;
        AttackHenshin();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTakeDamge>().TakeDamge(BaseAttack, Damge);
            CameraShake.Instance.ShakeCamera(5f, 0.1f);

        }
    }
    public void AttackHenshin()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint2.position, AttackRange2, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTakeDamge>().TakeDamge(BaseAttack, Damge);
            CameraShake.Instance.ShakeCamera(15f, 0.3f);

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);
        Gizmos.DrawWireCube(AttackPoint2.position, AttackRange2);
    }
}
