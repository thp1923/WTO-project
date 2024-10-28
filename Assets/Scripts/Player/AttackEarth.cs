using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEarth : MonoBehaviour
{
    int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask enemyLayer;

    public float DamgeSkill;
    public float cameraSize;
    public float zoomTime;

    float Damge;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
        audioManager.playSFX(audioManager.Earth);
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTakeDamge>().TakeDamge(BaseAttack, Damge);
            CameraShake.Instance.ShakeCamera(15f, 0.2f);

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
