using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : MonoBehaviour
{
    int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask enemyLayer;

    public float DamgeSkill;

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
    public void Skill()
    {
        Damge = BaseAttack * DamgeSkill;
        Attack();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTakeDamge>().TakeDamge(BaseAttack, Damge);
            CameraShake.Instance.ShakeCamera(8f, 0.1f);

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);

    }
    public void EndAttack()
    {
        FindObjectOfType<PlayerAttackUnitl>().EndUntil();
        gameObject.SetActive(false);
    }
}
